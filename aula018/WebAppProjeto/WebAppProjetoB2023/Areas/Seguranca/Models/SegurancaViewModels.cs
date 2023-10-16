﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppProjetoB2023.Areas.Seguranca.Models
{
    public class SegurancaViewModels
    {
        public class UsuarioViewModel
        {
            public string Id { get; set; }
            [Required]
            public string Nome { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Senha { get; set; }
        }
    }
}