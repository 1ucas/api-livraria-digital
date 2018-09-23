
namespace LivrariaApiModel.Dtos
{
    public class ComentarioDto : DtoBase
    {
        public string Conteudo { get; set; }
        public UsuarioDto Usuario { get; set; }
        public LivroDto Livro { get; set; }
    }
}
