using MediatR;
using Pedidos.Domain.Event;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Command.Productos.UpdateStockWhenItemPedidoAgregado
{

    public class UpdateStockWhenItemPedidoAgregadoHandler : INotificationHandler<ItemPedidoAgregado>
    {
        private readonly IProductoRepository _productoRepository;

        public UpdateStockWhenItemPedidoAgregadoHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public  async Task Handle(ItemPedidoAgregado notification, CancellationToken cancellationToken)
        {
            Producto objProducto = await _productoRepository.FindByIdAsync(notification.ProductoId);
            objProducto.ReducirStock(notification.Cantidad);

            await _productoRepository.UpdateAsync(objProducto);

        }
    }
}
