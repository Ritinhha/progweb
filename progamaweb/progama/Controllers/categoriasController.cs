using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using progama.Models;

namespace progama.Controllers
{
    public class categoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria(){Nome = "ação", CategoriaId = 1},
            new Categoria(){Nome = "ação", CategoriaId = 2},
            new Categoria(){Nome = "ação", CategoriaId = 3},
            new Categoria(){Nome = "ação", CategoriaId = 4},
            new Categoria(){Nome = "ação", CategoriaId = 5}
        };


        // GET: categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }
    }
}