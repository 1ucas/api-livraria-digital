
using System;

namespace LivrariaApiModel.Dtos
{
    public class LivroDto : DtoBase
    {
        public string Titulo { get; set; }
        public int EditoraId { get; set; }
        public int AutorId { get; set; }
        public string DataPublicacao { get; set; }
    }
}
