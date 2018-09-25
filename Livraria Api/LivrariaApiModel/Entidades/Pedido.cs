
using System.Collections.Generic;

namespace LivrariaApiModel.Entidades
{
    public class Pedido : EntidadeBase
    {
        public List<int> IdsLivros { get; set; }
        public float Valor { get; set; }
        public int IdUsuario { get; set; }
    }
}