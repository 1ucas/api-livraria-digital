using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiRepo
{
    public class AutorRepositorio : RepositorioBase
    {
        public static List<Autor> Autores = new List<Autor>(new Autor[] {
                                                            new Autor{
                                                                Id = 1,
                                                                Nome = "J. K. Rowling"
                                                            },
                                                            new Autor{
                                                                Id = 2,
                                                                Nome = "J. R. R. Tolkien"
                                                            }
        });
        public static List<Autor> Listar()
        {
            return Autores;
        }

        public static Autor ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Autor>(Autores, id);
        }

        public static int InserirNovoItem(AutorDto novoAutorDto)
        {
            var autor = new Autor
            {
                Nome = novoAutorDto.Nome
            };
            return RepositorioBase.InserirNovoItem<Autor>(Autores, autor);
        }

        public static AutorDto GerarDto(Autor autor)
        {
            return new AutorDto
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }

        public static List<AutorDto> GerarDto(List<Autor> autores)
        {
            var autoresDto = new List<AutorDto>();
            foreach (var autor in autores)
            {
                autoresDto.Add(new AutorDto
                {
                    Id = autor.Id,
                    Nome = autor.Nome
                });
            }
            return autoresDto;
        }
    }
}
