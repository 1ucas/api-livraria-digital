
using System;

namespace LivrariaApiModel.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Titulo { get; set; }
        public int EditoraId { get; set; }
        public int AutorId { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}