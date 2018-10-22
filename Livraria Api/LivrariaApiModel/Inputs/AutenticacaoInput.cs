using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiModel.Inputs
{
    public class AutenticacaoInput : BaseInput
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "senha")]
        public string Senha { get; set; }
    }
}
