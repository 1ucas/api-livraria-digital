using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LivrariaApiBusiness;

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
            var autor = new AutoresBusiness().ObterPeloId(id);
            if (autor == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, autor);
        }

        // POST: api/Autores
        public void Post([FromBody]AutorDto autor)
        {
            new AutoresBusiness().Criar(autor);
        }

        // PUT: api/Autores/5
        public void Put(int id, [FromBody]AutorDto autor)
        {
            new AutoresBusiness().Inserir(id, autor);
        }

        // DELETE: api/Autores/5
        public void Delete(int id)
        {
            new AutoresBusiness().Remover(id);
        }
    }
}
