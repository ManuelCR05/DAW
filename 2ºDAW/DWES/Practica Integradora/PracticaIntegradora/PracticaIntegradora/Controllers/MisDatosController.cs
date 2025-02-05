using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;

namespace PracticaIntegradora.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatosController : Controller
    {
        private readonly MvcTiendaContexto _context;
        public MisDatosController(MvcTiendaContexto context)
        {
            _context = context;
        }
        // GET: MisDatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MisDatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("Id,Nombre,Email,Telefono,Direccion,Poblacion,CodigoPostal,Nif")] Cliente empleado)
        {
            // Asignar el Email del usuario actual
            empleado.Email = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(empleado);
        }
    }
}
