
using LivrariaApiModel.Dtos;
using LivrariaApiModel.Inputs;
using LivrariaApiModel.Outputs;

namespace LivrariaApiServices
{
    public class PagamentoService : BaseService
    {
        public PagamentoService(string authToken) : base(authToken)
        {
            BaseRoute = "http://ms-payment.herokuapp.com/v1/private/";
        }

        public bool Pagar(int usuarioId, CartaoCreditoDto cartao, int livroId)
        {
            var input = new PagamentoInput
            {
               IdUsuario = usuarioId,
               Cartao = cartao,
               Descricao = "",
               IdLivro = livroId,
               Moeda = "R$",
               Valor = 50
            };
            var resp = Post<PagamentoOutput>("pagamentos", input, false);
            return resp.Sucesso;
        }
    }
}
