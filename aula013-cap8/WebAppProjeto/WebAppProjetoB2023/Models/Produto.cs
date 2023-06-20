using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProjetoB2023.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }

        public long? CategoriaId { get; set; } // chave estrangeira
        public long? FabricanteId { get; set; }

        public string LogotipoMimeType { get; set; } //tipo de imagem(png etc)
        public byte[] Logotipo { get; set; } //pega os bits da imagem(pixels)

        public Categoria Categoria { get; set; }// para carregar o objeto com o auxilio da chave estrangeiro
        public Fabricante Fabricante { get; set; }

       
    }
}