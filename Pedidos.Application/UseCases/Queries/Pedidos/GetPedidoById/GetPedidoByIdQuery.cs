using MediatR;
using Pedidos.Application.Dto.Pedido;
using System;

namespace Pedidos.Application.UseCases.Queries.Pedidos.GetPedidoById
{
    public class GetPedidoByIdQuery : IRequest<PedidoDto>
    {
        public Guid Id { get; set; }

        public GetPedidoByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetPedidoByIdQuery() { }
    }
}
