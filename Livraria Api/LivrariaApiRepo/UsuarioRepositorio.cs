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
        public static List<Usuario> Usuarios = new List<Usuario>();

        public static Usuario ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Usuario>(Usuarios, id);
        }

        public static UsuarioDto GerarDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome
            };
        }
    }
}
