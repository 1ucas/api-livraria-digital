using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiRepo
{
    public class UsuarioRepositorio
    {
        public static List<Usuario> Usuarios = new List<Usuario>(new Usuario[] {
                                                            new Usuario{
                                                                Id = 1,
                                                                Nome = "Usuario 1"
                                                            },
                                                            new Usuario{
                                                                Id = 2,
                                                                Nome = "Usuario 2"
                                                            }
        });
        public static List<Usuario> Listar()
        {
            return Usuarios;
        }

        public static Usuario ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Usuario>(Usuarios, id);
        }

        public static int InserirNovoItem(UsuarioDto novaUsuarioDto)
        {
            var usuario = new Usuario
            {
                Nome = novaUsuarioDto.Nome
            };
            return RepositorioBase.InserirNovoItem<Usuario>(Usuarios, usuario);
        }

        public static UsuarioDto GerarDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome
            };
        }

        public static List<UsuarioDto> GerarDto(List<Usuario> usuarios)
        {
            var usuariosDto = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                usuariosDto.Add(new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome
                });
            }
            return usuariosDto;
        }
    }
}
