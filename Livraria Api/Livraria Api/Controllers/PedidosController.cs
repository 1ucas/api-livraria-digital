using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class PedidosController : ApiController
    {
        // GET: api/Pedidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pedidos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedidos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedidos/5
        public void Delete(int id)
        {
        }
    }
}
