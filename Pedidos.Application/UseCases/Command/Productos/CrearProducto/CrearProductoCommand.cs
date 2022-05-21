using MediatR;
using System;

namespace Pedidos.Application.UseCases.Command.Productos.CrearProducto
{
    public class CrearProductoCommand : IRequest<Guid>
    {
        public int StockActual { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Nombre { get; set; }

        private CrearProductoCommand() { }

        public CrearProductoCommand(int stockActual, decimal precioVenta, string nombre)
        {
            StockActual = stockActual;
            PrecioVenta = precioVenta;
            Nombre = nombre;
        }
    }
}
