using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace Livraria_Api.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<UsuarioDto> Get()
        {
            return UsuarioRepositorio.GerarDto(UsuarioRepositorio.Listar());
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var usuario = UsuarioRepositorio.ObterPeloId(id);
            if (usuario == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK,
                UsuarioRepositorio.GerarDto(UsuarioRepositorio.ObterPeloId(id)));
        }

        // POST api/<controller>
        public void Post([FromBody]UsuarioDto usuario)
        {
            UsuarioRepositorio.InserirNovoItem(usuario);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]UsuarioDto usuario)
        {
            var usuarioExistente = UsuarioRepositorio.ObterPeloId(id);
            if (usuarioExistente == null)
            {
                usuario.Id = id;
                UsuarioRepositorio.InserirNovoItem(usuario);
            }
            else
            {
                usuarioExistente.Nome = usuario.Nome;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var usuarioExistente = UsuarioRepositorio.Usuarios.FirstOrDefault(c => c.Id == id);
            UsuarioRepositorio.Usuarios.Remove(usuarioExistente);
        }
    }
}