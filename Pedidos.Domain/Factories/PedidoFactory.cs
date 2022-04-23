using Pedidos.Domain.Model.Pedidos;

namespace Pedidos.Domain.Factories
{
    public class PedidoFactory : IPedidoFactory
    {
        public Pedido Create(string nroPedido)
        {
            return new Pedido(nroPedido);
        }
    }
}
