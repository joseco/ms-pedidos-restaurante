using MassTransit;
using MassTransit.Mediator;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using SharedKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Consumers
{
    public class StockArticuloActualizadoConsumer : IConsumer<StockArticuloActualizado>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public const string ExchangeName = "stock-articulo-actualizado-exchange";
        public const string QueueName = "stock-articulo-actualizado-inventario";

        public StockArticuloActualizadoConsumer(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<StockArticuloActualizado> context)
        {
            var @event = context.Message;

            Producto objProducto = await _productoRepository.FindByIdAsync(@event.ArticuloId);
            objProducto.UpdateStock(new Domain.Model.ValueObjects.CantidadValue((int)@event.NuevoStock));

            await _productoRepository.UpdateAsync(objProducto);

            await _unitOfWork.Commit();
        }
    }
}
