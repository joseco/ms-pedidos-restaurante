using MediatR;
using Microsoft.Extensions.Logging;
using Pedidos.Domain.Factories;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Command.Productos.CrearProducto
{

    public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, Guid>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<CrearProductoHandler> _logger;
        private readonly IProductoFactory _productoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProductoHandler(IProductoRepository productoRepository, ILogger<CrearProductoHandler> logger, IProductoFactory productoFactory, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _logger = logger;
            _productoFactory = productoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Producto objProducto = _productoFactory.Create(request.ArticuloId, request.Nombre, request.Descripcion, request.PrecioVenta, request.StockActual,
                    request.EsReceta);
                
                await _productoRepository.CreateAsync(objProducto);
                await _unitOfWork.Commit();

                return objProducto.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
            }
            return Guid.Empty;
        }
    }
}
