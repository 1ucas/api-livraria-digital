using Livraria_Api.Models;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class LivrosController : ApiController
    {
        // GET: api/Livros
        public IEnumerable<Livro> Get()
        {
            return LivroRepositorio.Livros;
        }

        // GET: api/Livros/5
        public Livro Get(int id)
        {
            return new Livro();
        }

        // POST: api/Livros
        public void Post([FromBody]Livro livro)
        {
            LivroRepositorio.Livros.Add(livro);
        }

        // PUT: api/Livros/5
        public void Put(int id, [FromBody]Livro livro)
        {
        }

        // DELETE: api/Livros/5
        public void Delete(int id)
        {
        }
    }
}
