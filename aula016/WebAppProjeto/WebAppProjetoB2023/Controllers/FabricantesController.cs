﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebAppProjetoB2023.Models;
using System.Net; // pro " new HttpStatusCodeResult(HttpStatusCode.BadRequest) " funcionar
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using servico.Tabelas;
using servico.Cadastros;

namespace WebAppProjetoB2023.Controllers
{
    public class FabricantesController : Controller
    {
        //EFContext context = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
       // private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Edit(long? id)
        {//a interrogação indica que esse parametro não é obrigatorio
            return ObterVisaoFabricantePorId(id);
        }



        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }


        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante" + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }
    }
}