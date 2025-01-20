using Microsoft.AspNetCore.Mvc;

namespace PracticaIntegradora.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
