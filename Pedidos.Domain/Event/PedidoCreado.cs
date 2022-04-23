using ShareKernel.Core;
using System;

namespace Pedidos.Domain.Event
{
    public record PedidoCreado : DomainEvent
    {
        public Guid PedidoId { get;  }
        public string NroPedido { get; }

        public PedidoCreado(Guid pedidoId,
            string nroPedido) : base(DateTime.Now)
        {
            PedidoId = pedidoId;
            NroPedido = nroPedido;

        }
    }
}
