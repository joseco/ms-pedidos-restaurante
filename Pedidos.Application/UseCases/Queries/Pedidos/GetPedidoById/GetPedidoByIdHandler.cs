using MediatR;
using Microsoft.Extensions.Logging;
using Pedidos.Application.Dto.Pedido;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Queries.Pedidos.GetPedidoById
{
    public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, PedidoDto>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<GetPedidoByIdQuery> _logger;

        public GetPedidoByIdHandler(IPedidoRepository pedidoRepository, ILogger<GetPedidoByIdQuery> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<PedidoDto> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            PedidoDto result = null;
            try
            {
                Pedido objPedido = await _pedidoRepository.FindByIdAsync(request.Id);

                result = new PedidoDto()
                {
                    Id = objPedido.Id,
                    NroPedido = objPedido.NroPedido,
                    Total = objPedido.Total
                };

                foreach (var item in objPedido.Detalle)
                {
                    result.Detalle.Add(new DetallePedidoDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Instrucciones,
                        Precio = item.Precio,
                        ProductoId = item.ProductoId
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Pedido con id: { PedidoId }", request.Id);
            }

            return result;
        }
    }
}
