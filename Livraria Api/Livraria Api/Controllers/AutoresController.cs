using LivrariaApiModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return new AutorDto[] { new AutorDto(), new AutorDto() };
        }

        // GET: api/Autores/5
        public AutorDto Get(int id)
        {
            return new AutorDto();
        }

        // POST: api/Autores
        public void Post([FromBody]AutorDto autor)
        {
        }

        // PUT: api/Autores/5
        public void Put(int id, [FromBody]AutorDto autor)
        {
        }

        // DELETE: api/Autores/5
        public void Delete(int id)
        {
        }
    }
}
