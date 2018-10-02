using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LivrariaApiBusiness;

namespace Livraria_Api.Controllers
{
    public class EditorasController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EditoraDto> Get()
        {
            return new EditorasBusiness().Listar();
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var editoraDto = new EditorasBusiness().ObterPeloId(id);
            if (editoraDto == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, editoraDto);
        }

        // POST api/<controller>
        public void Post([FromBody]EditoraDto editora)
        {
            new EditorasBusiness().Criar(editora);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]EditoraDto editora)
        {
            new EditorasBusiness().Inserir(id, editora);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            new EditorasBusiness().Remover(id);
        }
    }
}