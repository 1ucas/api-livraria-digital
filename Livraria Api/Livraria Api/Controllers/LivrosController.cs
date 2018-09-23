using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class LivrosController : ApiController
    {
        // GET: api/Livros 
        public IEnumerable<LivroDto> Get()
        {
            return LivroRepositorio.GerarDto(LivroRepositorio.Listar());
        }

        // GET: api/Livros/5
        public LivroDto Get(int id)
        {
            return new LivroDto();
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
