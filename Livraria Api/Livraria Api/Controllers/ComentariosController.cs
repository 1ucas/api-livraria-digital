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
        public IEnumerable<ComentarioDto> Get()
        {
            return ComentarioRepositorio.GerarDto(ComentarioRepositorio.Comentarios);
        }

        // GET: api/Comentarios/5
        public ComentarioDto Get(int id)
        {
            return ComentarioRepositorio.GerarDto(ComentarioRepositorio.ObterPeloId(id));
        }

        // POST: api/Comentarios
        public void Post([FromBody]ComentarioDto comentario)
        {
            ComentarioRepositorio.InserirNovoItem(comentario);
        }

        // PUT: api/Comentarios/5
        public void Put(int id, [FromBody]ComentarioDto comentario)
        {
            var comentarioExistente = ComentarioRepositorio.ObterPeloId(id);
            if(comentarioExistente == null)
            {
                comentario.Id = id;
                ComentarioRepositorio.InserirNovoItem(comentario);
            } else
            {
                // TODO
            }
        }

        // DELETE: api/Comentarios/5
        public void Delete(int id)
        {
            var comentarioExistente = ComentarioRepositorio.Comentarios.FirstOrDefault(c => c.Id == id);
            ComentarioRepositorio.Comentarios.Remove(comentarioExistente);
        }
    }
}
