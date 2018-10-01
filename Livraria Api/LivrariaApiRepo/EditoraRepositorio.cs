using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiRepo
{
    public class EditoraRepositorio
    {
        public static List<Editora> Editoras = new List<Editora>(new Editora[] {
                                                            new Editora{
                                                                Id = 1,
                                                                Nome = "Leia"
                                                            },
                                                            new Editora{
                                                                Id = 2,
                                                                Nome = "Moderna"
                                                            }
        });

        public static List<Editora> Listar()
        {
            return Editoras;
        }

        public static Editora ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Editora>(Editoras, id);
        }

        public static int InserirNovoItem(EditoraDto novaEditoraDto)
        {
            var editora = new Editora
            {
                Nome = novaEditoraDto.Nome
            };
            return RepositorioBase.InserirNovoItem<Editora>(Editoras, editora);
        }

        public static EditoraDto GerarDto(Editora editora)
        {
            return new EditoraDto
            {
                Id = editora.Id,
                Nome = editora.Nome
            };
        }

        public static List<EditoraDto> GerarDto(List<Editora> editoras)
        {
            var editorasDto = new List<EditoraDto>();
            foreach (var editora in editoras)
            {
                editorasDto.Add(new EditoraDto
                {
                    Id = editora.Id,
                    Nome = editora.Nome
                });
            }
            return editorasDto;
        }
    }
}
