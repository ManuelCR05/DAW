using Microsoft.AspNetCore.Mvc;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;

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
            carrito.Remove(id); // Eliminar un solo elemento con ese ID

            HttpContext.Session.SetString("Carrito", string.Join(",", carrito));
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmarCompra(int clienteId)
        {
            var carritoIds = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoIds)) return RedirectToAction("Index");

            var ids = carritoIds.Split(',').Select(int.Parse).ToList();
            var productos = _context.Productos.Where(p => ids.Contains(p.Id)).ToList();

            var nuevoPedido = new Pedido
            {
                Fecha = DateTime.Now,
                Confirmado = DateTime.Now,
                ClienteId = clienteId,
                EstadoId = 1,
                Detalles = productos.Select(p => new Detalle
                {
                    ProductoId = p.Id,
                    Cantidad = ids.Count(id => id == p.Id),
                    Precio = p.Precio,
                    Descuento = 0
                }).ToList()
            };

            _context.Pedidos.Add(nuevoPedido);
            _context.SaveChanges();

            HttpContext.Session.Remove("Carrito");

            return RedirectToAction("PedidoConfirmado", new { pedidoId = nuevoPedido.Id });
        }
    }
}
