﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProjetoB2023.Models
{
    public class home
    {
        public IQueryable<Categoria> Categorias;
        public IQueryable<Fabricante> Fabricantes;
    }
}