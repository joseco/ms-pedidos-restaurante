using MediatR;
using Pedidos.Application.Dto.Pedido;
using System;
using System.Collections.Generic;

namespace Pedidos.Application.UseCases.Command.Pedidos.CrearPedido
{
    public class CrearPedidoCommand : IRequest<Guid>
    {
        private CrearPedidoCommand() { }

        public CrearPedidoCommand(List<DetallePedidoDto> detalle)
        {
            Detalle = detalle;
        }

        public List<DetallePedidoDto> Detalle { get; set; }

        

    }
}
