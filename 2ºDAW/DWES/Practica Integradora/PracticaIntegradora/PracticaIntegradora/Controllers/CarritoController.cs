using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;
using System.Security.Claims;

namespace PracticaIntegradora.Controllers
{
    public class CarritoController : Controller
    {
        private readonly MvcTiendaContexto _context;

        public CarritoController(MvcTiendaContexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carritoIds = HttpContext.Session.GetString("Carrito");
            List<Carrito> carrito = new List<Carrito>();

            if (!string.IsNullOrEmpty(carritoIds))
            {
                var ids = carritoIds.Split(',').Select(int.Parse).ToList();
                carrito = _context.Productos
                    .Where(p => ids.Contains(p.Id))
                    .Select(p => new Carrito
                    {
                        ProductoId = p.Id,
                        Nombre = p.Descripcion,
                        Precio = p.Precio,
                        Cantidad = ids.Count(id => id == p.Id),
                        Imagen = p.Imagen
                    })
                    .ToList();
            }

            return View(carrito);
        }

        public IActionResult Agregar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            var carritoIds = HttpContext.Session.GetString("Carrito");
            List<int> carrito = string.IsNullOrEmpty(carritoIds) ? new List<int>() : carritoIds.Split(',').Select(int.Parse).ToList();

            carrito.Add(id);
            HttpContext.Session.SetString("Carrito", string.Join(",", carrito));

            return RedirectToAction("Index", "Carrito");
        }

        public IActionResult Decrementar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            var carritoIds = HttpContext.Session.GetString("Carrito");
            List<int> carrito = string.IsNullOrEmpty(carritoIds) ? new List<int>() : carritoIds.Split(',').Select(int.Parse).ToList();

            carrito.Remove(id);
            HttpContext.Session.SetString("Carrito", string.Join(",", carrito));

            return RedirectToAction("Index", "Carrito");
        }

        public IActionResult Eliminar(int id)
        {
            var carritoIds = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoIds)) return RedirectToAction("Index");

            List<int> carrito = carritoIds.Split(',').Select(int.Parse).ToList();

            carrito.RemoveAll(x => x == id);

            HttpContext.Session.SetString("Carrito", string.Join(",", carrito));

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Usuario")]
        public IActionResult ConfirmarCompra()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == userEmail);

            var clienteId = cliente.Id;

            var carritoIdsString = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoIdsString))
            {
                return Content("El carrito está vacío.");
            }

            var productoIds = carritoIdsString.Split(',').Select(int.Parse).ToList();

            var estadoConfirmado = _context.Estados.FirstOrDefault(e => e.Descripcion == "Confirmado");
            if (estadoConfirmado == null)
            {
                return Content("Error: Estado 'Confirmado' no encontrado.");
            }

            var nuevoPedido = new Pedido
            {
                Fecha = DateTime.Now,
                Confirmado = DateTime.Now,
                ClienteId = clienteId,
                EstadoId = estadoConfirmado.Id,
                Cliente = cliente,
                Estado = estadoConfirmado,
                Detalles = new List<Detalle>()
            };

            var productos = _context.Productos.Where(p => productoIds.Contains(p.Id)).ToList();

            foreach (var producto in productos)
            {
                int cantidad = productoIds.Count(id => id == producto.Id);

                nuevoPedido.Detalles.Add(new Detalle
                {
                    ProductoId = producto.Id,
                    Cantidad = cantidad,
                    Precio = producto.Precio,
                    Descuento = 0
                });
            }

            _context.Pedidos.Add(nuevoPedido);
            _context.SaveChanges();

            HttpContext.Session.Remove("Carrito");

            return RedirectToAction("DetallesPedido", "Pedidos", new { id = nuevoPedido.Id });
        }

    }
}
