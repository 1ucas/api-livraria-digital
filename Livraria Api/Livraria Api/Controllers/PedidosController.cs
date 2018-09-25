using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace Livraria_Api.Controllers
{
    public class PedidosController : ApiController
    {
        // GET: api/Pedidos
        public IEnumerable<PedidoDto> Get()
        {
            var pedidos = PedidoRepositorio.Listar(); 
            return PedidoRepositorio.GerarDto(pedidos);
        }

        // GET: api/Pedidos/5
        public HttpResponseMessage Get(int id)
        {
            var pedido = PedidoRepositorio.ObterPeloId(id);
            if (pedido == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK,
                PedidoRepositorio.GerarDto(PedidoRepositorio.ObterPeloId(id)));
        }

        // POST: api/Pedidos
        public void Post([FromBody]PedidoDto pedido)
        {
            PedidoRepositorio.InserirNovoItem(pedido);
        }

        // PUT: api/Pedidos/5
        public void Put(int id, [FromBody]PedidoDto pedido)
        {
            var pedidoExistente = PedidoRepositorio.ObterPeloId(id);
            if (pedidoExistente == null)
            {
                pedido.Id = id;
                PedidoRepositorio.InserirNovoItem(pedido);
            }
            else
            {
                //TODO
            }
        }

        // DELETE: api/Pedidos/5
        public void Delete(int id)
        {
            var pedidoExistente = PedidoRepositorio.Pedidos.FirstOrDefault(c => c.Id == id);
            PedidoRepositorio.Pedidos.Remove(pedidoExistente);
        }
    }
}
