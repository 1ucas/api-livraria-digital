using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class AutoresController : ApiController
    {
        // GET: api/Autores
        public IEnumerable<AutorDto> Get()
        {
            return AutorRepositorio.GerarDto(AutorRepositorio.Listar());
        }

        // GET: api/Autores/5
        public HttpResponseMessage Get( int id)
        {
            var autor = AutorRepositorio.ObterPeloId(id);
            if (autor == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK,
                AutorRepositorio.GerarDto(AutorRepositorio.ObterPeloId(id)));
        }

        // POST: api/Autores
        public void Post([FromBody]AutorDto autor)
        {
            AutorRepositorio.InserirNovoItem(autor);
        }

        // PUT: api/Autores/5
        public void Put(int id, [FromBody]AutorDto autor)
        {
            var autorExistente = AutorRepositorio.ObterPeloId(id);
            if (autorExistente == null)
            {
                autor.Id = id;
                AutorRepositorio.InserirNovoItem(autor);
            }
            else
            {
                autorExistente.Nome = autor.Nome;
            }
        }

        // DELETE: api/Autores/5
        public void Delete(int id)
        {
            var autorExistente = AutorRepositorio.Autores.FirstOrDefault(c => c.Id == id);
            AutorRepositorio.Autores.Remove(autorExistente);
        }
    }
}
