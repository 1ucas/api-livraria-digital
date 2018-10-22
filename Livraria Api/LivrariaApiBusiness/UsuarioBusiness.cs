using LivrariaApiModel.Dtos;
using LivrariaApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class UsuarioBusiness
    {
        public void Login(UsuarioDto usuario)
        {
            var response = new AutenticacaoService("").Login(usuario);
        }
    }
}
