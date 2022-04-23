using MediatR;
using Microsoft.Extensions.Logging;
using Pedidos.Application.Services;
using Pedidos.Domain.Factories;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Command.Pedidos.CrearPedido
{
    public class CrearPedidoHandler : IRequestHandler<CrearPedidoCommand, Guid>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<CrearPedidoHandler> _logger;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoFactory _pedidoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPedidoHandler(IPedidoRepository pedidoRepository, 
            ILogger<CrearPedidoHandler> logger,
            IPedidoService pedidoService, 
            IPedidoFactory pedidoFactory, 
            IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _pedidoService = pedidoService;
            _pedidoFactory = pedidoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string nroPedido = await _pedidoService.GenerarNroPedidoAsync();
                Pedido objPedido = _pedidoFactory.Create(nroPedido);

                foreach (var item in request.Detalle)
                {
                    objPedido.AgregarItem(item.ProductoId, item.Cantidad, item.Precio, item.Instrucciones);
                }

                objPedido.ConsolidarPedido();

                await _pedidoRepository.CreateAsync(objPedido);

                await _unitOfWork.Commit();

                return objPedido.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}
