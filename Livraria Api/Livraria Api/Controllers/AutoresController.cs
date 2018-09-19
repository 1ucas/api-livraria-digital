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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Autores/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Autores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Autores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Autores/5
        public void Delete(int id)
        {
        }
    }
}
