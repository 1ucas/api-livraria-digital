using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaApiRepo
{
    public class PedidoRepositorio : RepositorioBase
    {
        public static List<Pedido> Pedidos = new List<Pedido>(new Pedido[] {
                                                            new Pedido{
                                                                Id = 1,
                                                                IdsLivros = new List<int>(new int[]{1,2}),
                                                                IdUsuario = 1
                                                            },
                                                            new Pedido{
                                                                Id = 2,
                                                                IdsLivros = new List<int>(new int[]{3,4}),
                                                                IdUsuario = 1
                                                            }
        });

        public static List<Pedido> Listar()
        {
            return Pedidos;
        }


        public static Pedido ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Pedido>(Pedidos, id);
        }

        public static int InserirNovoItem(PedidoDto novoPedidoDto)
        {
            var pedido = new Pedido
            {
                IdsLivros = novoPedidoDto.Livros.Select(p => p.Id).ToList(),
                IdUsuario = novoPedidoDto.Usuario.Id,
                Valor = novoPedidoDto.Valor
            };
            return RepositorioBase.InserirNovoItem<Pedido>(Pedidos, pedido);
        }

        public static PedidoDto GerarDto(Pedido pedido)
        {
            var livros = new List<Livro>();
            pedido.IdsLivros.ForEach(
                id => livros.Add(LivroRepositorio.ObterPeloId(id)));
            var usuario = UsuarioRepositorio.ObterPeloId(pedido.IdUsuario);
            return new PedidoDto
            {
                Id = pedido.Id,
                Livros = LivroRepositorio.GerarDto(livros),
                Usuario = UsuarioRepositorio.GerarDto(usuario),
                Valor = pedido.Valor
            };
        }

        public static List<PedidoDto> GerarDto(List<Pedido> pedidos)
        {
            var pedidosDto = new List<PedidoDto>();
            pedidos.ForEach(pedido => pedidosDto.Add(GerarDto(pedido)));
            return pedidosDto;
        }
    }
}
