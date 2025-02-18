using Microsoft.AspNetCore.Mvc;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace PracticaIntegradora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcTiendaContexto _context;

        public HomeController(ILogger<HomeController> logger, MvcTiendaContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string? emailUsuario = User.Identity.Name;
            Cliente? empleado = _context.Clientes.Where(e => e.Email == emailUsuario)
            .FirstOrDefault();
            if (User.Identity.IsAuthenticated &&
                User.IsInRole("Usuario") &&
                empleado == null)
            {
                return RedirectToAction("Create", "MisDatos");
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
