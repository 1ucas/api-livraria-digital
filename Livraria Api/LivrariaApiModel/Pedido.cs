using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Api.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Livro> Livros { get; set; }
    }
}