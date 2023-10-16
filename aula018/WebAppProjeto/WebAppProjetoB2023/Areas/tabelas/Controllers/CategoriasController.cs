using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
//using WebAppProjetoB2023.Models;
using System.Net;
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using servico.Cadastros;
using servico.Tabelas;

namespace WebAppProjetoB2023.Areas.tabelas.Controllers
{
    public class CategoriasController : Controller
    {

        //EFContext context = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias

        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }


        public ActionResult Create()
        {
            return View();
        }



        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            return GravarCategoria(cat);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            return GravarCategoria(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }


    }
}