using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System.Collections.Generic;

namespace LivrariaApiRepo
{
    public class ComentarioRepositorio : RepositorioBase
    {
        public static List<Comentario> Comentarios = new List<Comentario>();

        public static Comentario ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Comentario>(Comentarios, id);
        }

        public static int InserirNovoItem(ComentarioDto novoComentarioDto)
        {
            var comentario = new Comentario
            {
                IdLivro = novoComentarioDto.Livro.Id,
                IdUsuario = novoComentarioDto.Usuario.Id,
                Conteudo = novoComentarioDto.Conteudo
            };
            return RepositorioBase.InserirNovoItem<Comentario>(Comentarios, comentario);
        }

        public static ComentarioDto GerarDto(Comentario comentario)
        {
            var livro = LivroRepositorio.ObterPeloId(comentario.IdLivro);
            var usuario = UsuarioRepositorio.ObterPeloId(comentario.IdUsuario);
            return new ComentarioDto
            {
                Id = comentario.Id,
                Livro = LivroRepositorio.GerarDto(livro),
                Usuario = UsuarioRepositorio.GerarDto(usuario),
                Conteudo = comentario.Conteudo
            };
        }

        public static List<ComentarioDto> GerarDto(List<Comentario> comentarios)
        {
            var comentariosDto = new List<ComentarioDto>();
            foreach (var comentario in comentarios)
            {
                var livro = LivroRepositorio.ObterPeloId(comentario.IdLivro);
                var usuario = UsuarioRepositorio.ObterPeloId(comentario.IdUsuario);
                comentariosDto.Add(new ComentarioDto
                {
                    Id = comentario.Id,
                    Livro = LivroRepositorio.GerarDto(livro),
                    Usuario = UsuarioRepositorio.GerarDto(usuario),
                    Conteudo = comentario.Conteudo
                });
            }
            return comentariosDto;
        }
    }
}
