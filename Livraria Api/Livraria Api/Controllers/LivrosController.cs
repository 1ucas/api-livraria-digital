using LivrariaApiBusiness;
using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    [RoutePrefix("api/livros")]
    public class LivrosController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(int id = 0, string titulo = null, int autor = 0, int editora = 0)
        {
            var livrosFiltrados = new LivrosBusiness().Filtrar(id, titulo, autor, editora);
            if (livrosFiltrados != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, livrosFiltrados);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        // POST: api/Livros
        public void Post([FromBody]LivroDto livro)
        {
            new LivrosBusiness().Criar(livro);
        }

        // PUT: api/Livros/5
        public void Put(int id, [FromBody]LivroDto livro)
        {
            new LivrosBusiness().Inserir(id, livro);
        }

        // DELETE: api/Livros/5
        public void Delete(int id)
        {
            new LivrosBusiness().Remover(id);
        }
    }
}
