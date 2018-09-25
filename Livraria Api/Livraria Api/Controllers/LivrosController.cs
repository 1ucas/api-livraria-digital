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
            var livrosFiltrados = LivroRepositorio.Listar().Where(l => (id == 0 ? true : l.Id == id) &&
                                                            (editora == 0 ? true : l.EditoraId == editora) &&
                                                                (autor == 0 ? true : l.AutorId == autor) && 
                                                                    (titulo == null ? true : l.Titulo.Contains(titulo))).ToList();
            if(livrosFiltrados.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                LivroRepositorio.GerarDto(livrosFiltrados));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        // POST: api/Livros
        public void Post([FromBody]LivroDto livro)
        {
            LivroRepositorio.InserirNovoItem(livro);
        }

        // PUT: api/Livros/5
        public void Put(int id, [FromBody]LivroDto livro)
        {
        }

        // DELETE: api/Livros/5
        public void Delete(int id)
        {
        }
    }
}
