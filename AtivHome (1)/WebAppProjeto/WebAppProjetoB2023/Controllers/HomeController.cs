using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;

namespace WebAppProjetoB2023.Controllers
{
    public class HomeController : Controller
    {
        EFContext Context = new EFContext();
        // GET: Home
        public ActionResult Index()
        {
            home h = new home();
            h.Categorias = Context.Categorias.OrderBy(c => c.Nome);
            h.Fabricantes = Context.Fabricantes.OrderBy(c => c.nome);

            return View(h);
        }
    }
}