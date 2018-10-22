using LivrariaApiModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiModel.Inputs
{
    public class PagamentoInput : BaseInput
    {
        public int IdUsuario { get; set; }
        public CartaoCreditoDto Cartao { get; set; }
        public int Valor { get; set; }
        public string Descricao { get; set; }
        public string Moeda { get; set; }
        public int IdLivro { get; set; }
    }
}
