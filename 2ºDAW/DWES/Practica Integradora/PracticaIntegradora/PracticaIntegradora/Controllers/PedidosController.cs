using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;

namespace PracticaIntegradora.Controllers
{
    public class PedidosController : Controller
    {
        private readonly MvcTiendaContexto _context;

        public PedidosController(MvcTiendaContexto context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pedidos
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var pedidos = from s in _context.Pedidos.Include(p => p.Cliente).Include(p => p.Estado)
                          select s;

            int pageSize = 10;
            return View(await PaginatedList<Pedido>.CreateAsync(pedidos.AsNoTracking(),
                pageNumber ?? 1, pageSize));
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/MisPedidos
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> MisPedidos()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == userEmail);
            if (cliente == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .Where(p => p.ClienteId == cliente.Id)
                .ToListAsync();

            return View(pedidos);
        }

        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> DetallesPedido(int id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == userEmail);
            if (cliente == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(p => p.Id == id && p.ClienteId == cliente.Id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> CancelarPedido(int id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == userEmail);
            if (cliente == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(p => p.Id == id && p.ClienteId == cliente.Id);

            if (pedido == null)
            {
                return BadRequest("El pedido no puede ser cancelado.");
            }

            var estadoCancelado = await _context.Estados.FirstOrDefaultAsync(e => e.Descripcion == "Anulado");
            if (estadoCancelado == null)
            {
                return BadRequest("Estado de cancelación no encontrado.");
            }

            pedido.EstadoId = estadoCancelado.Id;
            _context.Update(pedido);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MisPedidos));
        }



        [Authorize(Roles = "Administrador")]
        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Confirmado,Preparado,Enviado,Cobrado,Devuelto,Anulado,ClienteId,EstadoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Confirmado,Preparado,Enviado,Cobrado,Devuelto,Anulado,ClienteId,EstadoId")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
