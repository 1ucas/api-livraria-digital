using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System.Collections.Generic;

namespace LivrariaApiRepo
{
    public class LivroRepositorio : RepositorioBase
    {
        public static List<Livro> Livros = new List<Livro>();

        public static List<Livro> Listar()
        {
            return Livros;
        }

        public static Livro ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Livro>(Livros, id);
        }

        public static int InserirNovoItem(LivroDto novoLivroDto)
        {
            var novoLivro = new Livro
            {
                EditoraId = novoLivroDto.EditoraId,
                Titulo = novoLivroDto.Titulo
            };
            return RepositorioBase.InserirNovoItem<Livro>(Livros, novoLivro);
        }

        public static LivroDto GerarDto(Livro Livro)
        {
            return new LivroDto
            {
                Id = Livro.Id,
                EditoraId = Livro.EditoraId,
                Titulo = Livro.Titulo
            };
        }

        public static List<LivroDto> GerarDto(List<Livro> livros)
        {
            List<LivroDto> livrosDto = new List<LivroDto>();
            foreach (var livro in livros) {
                livrosDto.Add(new LivroDto
                {
                    Id = livro.Id,
                    EditoraId = livro.EditoraId,
                    Titulo = livro.Titulo
                });
            }
            return livrosDto;
        }
    }
}
