using LivrariaApiBusiness;
using LivrariaApiModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class LoginController : ApiController
    {
        public void Post([FromBody]UsuarioDto usuario)
        {
            new UsuarioBusiness().Login(usuario);
        }
    }
}
