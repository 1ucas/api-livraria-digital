
using LivrariaApiModel.Dtos;
using LivrariaApiModel.Inputs;
using LivrariaApiModel.Outputs;

namespace LivrariaApiServices
{
    public class AutenticacaoService : BaseService
    {
        public AutenticacaoService(string authToken) : base(authToken)
        {
        }

        public string Login(UsuarioDto usuario)
        {
            var input = new AutenticacaoInput
            {
                Login = usuario.Nome,
                Senha = usuario.Senha
            };
            var response = Post<AutenticacaoOutput>("autenticacao", input, false);
            return response.AccessToken;
        }
    }
}
