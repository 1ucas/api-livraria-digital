using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiModel.Dtos
{
    public class CartaoCreditoDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Cvc { get; set; }
        public string MesExp { get; set; }
        public string AnoExp { get; set; }

        public CartaoCreditoDto()
        {
        }
    }
}
