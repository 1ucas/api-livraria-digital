using System.Net;

namespace LivrariaApiModel.Outputs
{
    public class BaseOutput
    {
        public string MensagemErro { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public bool DeveFazerLogout
        {
            get
            {
                return StatusCode == HttpStatusCode.Unauthorized;
            }
        }

        public bool Sucesso
        {
            get
            {
                return StatusCode == HttpStatusCode.OK;
            }
        }
    }
}
