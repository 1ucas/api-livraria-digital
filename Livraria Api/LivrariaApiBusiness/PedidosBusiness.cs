using LivrariaApiModel.Dtos;
using LivrariaApiRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApiBusiness
{
    public class PedidosBusiness
    {
        public List<PedidoDto> Listar()
        {
            return PedidoRepositorio.GerarDto(PedidoRepositorio.Listar());
        }

        public PedidoDto ObterPeloId(int id)
        {
            return PedidoRepositorio.GerarDto(PedidoRepositorio.ObterPeloId(id));
        }

        public int Criar(PedidoDto pedido)
        {
            return PedidoRepositorio.InserirNovoItem(pedido);
        }

        public int Inserir(int id, PedidoDto pedido)
        {
            var pedidoExistente = PedidoRepositorio.ObterPeloId(id);
            if (pedidoExistente == null)
            {
                pedido.Id = id;
                return PedidoRepositorio.InserirNovoItem(pedido);
            }
            else
            {
                pedidoExistente.IdUsuario = pedido.Usuario.Id;
                pedidoExistente.Valor = pedido.Valor;
                pedidoExistente.IdsLivros = pedido.Livros.Select(l => l.Id).ToList();
                return id;
            } 
        }

        public void Remover(int id)
        {
            var pedidoExistente = PedidoRepositorio.Pedidos.FirstOrDefault(c => c.Id == id);
            PedidoRepositorio.Pedidos.Remove(pedidoExistente);
        }
    }
}

