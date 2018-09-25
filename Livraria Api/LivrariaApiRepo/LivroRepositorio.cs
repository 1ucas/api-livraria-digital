using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System.Collections.Generic;

namespace LivrariaApiRepo
{
    public class LivroRepositorio : RepositorioBase
    {
        public static List<Livro> Livros = new List<Livro>(new Livro[] {
                                                            new Livro{
                                                                Id = 1,
                                                                Titulo = "Harry Potter e a Pedra Filosofal",
                                                                EditoraId = 1,
                                                                AutorId = 1
                                                            },
                                                            new Livro{
                                                                Id = 2,
                                                                Titulo = "Harry Potter e a Câmara Secreta",
                                                                EditoraId = 1,
                                                                AutorId = 1
                                                            },
                                                            new Livro{
                                                                Id = 3,
                                                                Titulo = "O Senhor dos Anéis",
                                                                EditoraId = 2,
                                                                AutorId = 2
                                                            },
                                                            new Livro{
                                                                Id = 4,
                                                                Titulo = "O Silmarillion",
                                                                EditoraId = 2,
                                                                AutorId = 2
                                                            }
        });

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
                    Titulo = livro.Titulo,
                    AutorId = livro.AutorId
                });
            }
            return livrosDto;
        }
    }
}
