﻿using Modelo.Tabelas;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }
        public Categoria ObterCategoriaPorId(long id)
        {
            if (id == 0)
                return context.Categorias.Find(id);
            else
                return context.Categorias.Where(f => f.CategoriaId == id).Include("Produtos.Fabricante").First();
        }
        public void GravarCategoria(Categoria categoria)
        {

            Categoria categoria1 = ObterCategoriaPorId(categoria.CategoriaId);
            if (categoria1 == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
