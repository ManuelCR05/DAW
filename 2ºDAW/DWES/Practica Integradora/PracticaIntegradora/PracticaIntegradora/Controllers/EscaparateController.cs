using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using PracticaIntegradora.Data;
using PracticaIntegradora.Models;

namespace PracticaIntegradora.Controllers
{
    public class EscaparateController : Controller
    {
        private readonly MvcTiendaContexto _context;

        public EscaparateController(MvcTiendaContexto context)
        {
            _context = context;
        }

        public IActionResult Index(int? IdCategoria)
        {
            var viewProductosCategorias = new ViewEscaparate
            {
                Productos = _context.Productos.Where(producto => producto.Escaparate == true && 
                                                    (!IdCategoria.HasValue || producto.Categoria.Id == IdCategoria)).ToList(),
                Categorias = _context.Categorias.ToList()
            };

            //var productos = _context.Productos.Where(producto => producto.Escaparate == true);

            return View(viewProductosCategorias);
        }
    }
}
