
using System.Collections.Generic;

namespace LivrariaApiModel.Entidades
{
    public class Pedido : EntidadeBase
    {
        public List<Livro> Livros { get; set; }
    }
}