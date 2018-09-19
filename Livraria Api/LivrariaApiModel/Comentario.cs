using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Api.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public int IdUsuario { get; set; }
    }
}