using Pedidos.Domain.Model.Pedidos;

namespace Pedidos.Domain.Factories
{
    public interface IPedidoFactory
    {
        Pedido Create(string nroPedido);
    }
}
