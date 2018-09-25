using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace Livraria_Api.Controllers
{
    public class EditorasController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EditoraDto> Get()
        {
            return EditoraRepositorio.GerarDto(EditoraRepositorio.Listar());
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var editora = EditoraRepositorio.ObterPeloId(id);
            if (editora == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK,
                EditoraRepositorio.GerarDto(EditoraRepositorio.ObterPeloId(id)));
        }

        // POST api/<controller>
        public void Post([FromBody]EditoraDto editora)
        {
            EditoraRepositorio.InserirNovoItem(editora);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]EditoraDto editora)
        {
            var editoraExistente = EditoraRepositorio.ObterPeloId(id);
            if (editoraExistente == null)
            {
                editora.Id = id;
                EditoraRepositorio.InserirNovoItem(editora);
            }
            else
            {
                editoraExistente.Nome = editora.Nome;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var editoraExistente = EditoraRepositorio.Editoras.FirstOrDefault(c => c.Id == id);
            EditoraRepositorio.Editoras.Remove(editoraExistente);
        }
    }
}