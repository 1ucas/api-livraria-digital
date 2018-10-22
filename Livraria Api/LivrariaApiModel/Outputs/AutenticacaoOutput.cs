using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiModel.Outputs
{
    public class AutenticacaoOutput : BaseOutput
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
