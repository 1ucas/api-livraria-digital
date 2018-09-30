using LivrariaApiModel;
using LivrariaApiModel.Inputs;
using LivrariaApiModel.Outputs;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiIntegracoes
{
    public abstract class BaseService
    {
        private string BaseURL
        {
            get
            {
                return "http://www.convitinhos.com/api";
            }
        }

        private string BasePath
        {
            get
            {
                return string.IsNullOrEmpty(BaseRoute) ? BaseURL : BaseURL + BaseRoute;
            }
        }

        private string AuthToken { get; set; }

        private string AppVersion { get; set; }

        private static HttpClient client = new HttpClient();

        public BaseService(string authToken, string appVersion)
        {
            AuthToken = authToken;
            AppVersion = appVersion;
        }

        public string BaseRoute { get; set; }

        public T Get<T>(string path, bool canRetry = true) where T : BaseOutput
        {
            return Execute<T>(path, null, MethodHttp.GET, canRetry);
        }

        public T Post<T>(string path, BaseInput input, bool canRetry = true) where T : BaseOutput
        {
            return Execute<T>(path, input, MethodHttp.POST, canRetry);
        }

        private T Execute<T>(string path, BaseInput input, MethodHttp method, bool canRetry) where T : BaseOutput
        {
            int i = 0;
            T response;
            do
            {
                response = InnerExecute<T>(path, input, method);
                i++;
            } while (response.StatusCode == HttpStatusCode.PartialContent && i < 2 && canRetry);
            return response;
        }

        private T InnerExecute<T>(string path, BaseInput input, MethodHttp method) where T : BaseOutput
        {
            ConfigureClient(client, path);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.PartialContent);
            Task<HttpResponseMessage> resposta;
            if (method == MethodHttp.GET)
            {
                resposta = client.GetAsync("");
            }
            else
            {
                if (input == null)
                {
                    input = new BaseInput();
                }
                StringContent content = ConvertBodyToContent(input);
                resposta = client.PostAsync("", content);
            }

            try { response = resposta.Result; }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            };

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = Activator.CreateInstance<T>();
                errorResponse.StatusCode = response.StatusCode;
                if (response.StatusCode == HttpStatusCode.PartialContent)
                {
                    errorResponse.MensagemErro = "Não foi possível se conectar com nosso servidor. Verifique a conexão de seu celular e tente novamente mais tarde.";
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    errorResponse.MensagemErro = response.ReasonPhrase;
                }
                else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    errorResponse.MensagemErro = "Estamos passando por uma instabilidade em nossos servidores. Tente novamente mais tarde.";
                }
                else
                {
                    errorResponse.MensagemErro = "Ocorreu um erro. Tente novamente mais tarde.";
                }
                return errorResponse;
            }
            return ReadResponseContent<T>(response);
        }

        private static T ReadResponseContent<T>(HttpResponseMessage response) where T : BaseOutput
        {
            using (HttpContent responseContent = response.Content)
            {
                string data = responseContent.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(data);
                return result;
            }
        }

        private StringContent ConvertBodyToContent(BaseInput body)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return content;
        }

        private void ConfigureClient(HttpClient client, string path)
        {
            client.Timeout = new TimeSpan(0, 0, 7);
            client.BaseAddress = new Uri(BasePath + path);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-User-Token", AuthToken);
            client.DefaultRequestHeaders.Add("X-App-Version", AppVersion);
        }

        private enum MethodHttp
        {
            GET,
            POST
        }
    }
}
