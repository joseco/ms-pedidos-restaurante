using MassTransit;
using MediatR;
using Pedidos.Application.UseCases.Command.Productos.CrearProducto;
using SharedKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Consumers
{
    public class ArticuloCreadoConsumer : IConsumer<ArticuloCreado>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "articulo-creado-exchange";
        public const string QueueName = "articulo-creado-inventario";

        public ArticuloCreadoConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ArticuloCreado> context)
        {
            ArticuloCreado @event = context.Message;

            CrearProductoCommand command = new CrearProductoCommand(@event.ArticuloId, 0, @event.PrecioVenta, @event.Nombre);

            await _mediator.Send(command);

        }
    }
}
