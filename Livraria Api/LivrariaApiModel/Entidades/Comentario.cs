
namespace LivrariaApiModel.Entidades
{
    public class Comentario : EntidadeBase
    {
        public string Conteudo { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
    }
}