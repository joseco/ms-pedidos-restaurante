using Pedidos.Domain.Event;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Model.Pedidos
{
    public class Pedido : AggregateRoot<Guid>
    {
        public string NroPedido;
        public ICollection<DetallePedido> Detalle { get; private set; }

        public Pedido(string nroPedido)
        {
            Id = Guid.NewGuid();
            NroPedido = nroPedido;
            Detalle = new List<DetallePedido>();
        }

        public void ConsolidarPedido()
        {
            var evento = new PedidoCreado(Id, NroPedido);
            AddDomainEvent(evento);
        }
    }
}
