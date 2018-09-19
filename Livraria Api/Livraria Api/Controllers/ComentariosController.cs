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
    public class ComentariosController : ApiController
    {
        // GET: api/Comentarios
        public IEnumerable<Comentario> Get()
        {
            return ComentarioRepositorio.Comentarios;
        }

        // GET: api/Comentarios/5
        public Comentario Get(int id)
        {
            return ComentarioRepositorio.Comentarios.FirstOrDefault(c => c.Id == id);
        }

        // POST: api/Comentarios
        public void Post([FromBody]Comentario comentario)
        {
            comentario.Id = ComentarioRepositorio.Comentarios.Count == 0 ? 1 : ComentarioRepositorio.Comentarios.Max(c=> c.Id) + 1;
            ComentarioRepositorio.Comentarios.Add(comentario);
        }

        // PUT: api/Comentarios/5
        public void Put(int id, [FromBody]Comentario comentario)
        {
            var comentarioExistente = ComentarioRepositorio.Comentarios.FirstOrDefault(c => c.Id == id);
            if(comentarioExistente == null)
            {
                comentario.Id = id;
                ComentarioRepositorio.Comentarios.Add(comentario);
            } else
            {
                comentarioExistente.IdUsuario = comentario.IdUsuario;
                comentarioExistente.Conteudo = comentario.Conteudo;
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
