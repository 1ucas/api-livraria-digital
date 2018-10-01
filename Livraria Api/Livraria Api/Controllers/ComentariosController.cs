using LivrariaApiBusiness;
using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Livraria_Api.Controllers
{
    public class ComentariosController : ApiController
    {
        // GET: api/Comentarios
        public IEnumerable<ComentarioDto> Get(int pagina, int itensPorPagina)
        {
            return new ComentariosBusiness().Listar(pagina, itensPorPagina);
        }

        // GET: api/Comentarios/5
        public ComentarioDto Get(int id)
        {
            return new ComentariosBusiness().ObterPeloId(id);
        }

        // POST: api/Comentarios
        public void Post([FromBody]ComentarioDto comentario)
        {
            new ComentariosBusiness().Criar(comentario);
        }

        // PUT: api/Comentarios/5
        public void Put(int id, [FromBody]ComentarioDto comentario)
        {
            new ComentariosBusiness().Inserir(id, comentario);
        }

        // DELETE: api/Comentarios/5
        public void Delete(int id)
        {
            new ComentariosBusiness().Remover(id);
        }
    }
}
