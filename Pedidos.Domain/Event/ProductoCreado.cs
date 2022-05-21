using ShareKernel.Core;
using System;

namespace Pedidos.Domain.Event
{
    public record ProductoCreado : DomainEvent
    {
        public Guid ProductoId { get; }
        public string Nombre { get; }
        public int StockActual { get; set; }
        public decimal PrecioVenta { get; set; }

        public ProductoCreado(Guid productoId, string nombre, int stockActual, decimal precioVenta) : base(DateTime.Now)
        {
            ProductoId = productoId;
            Nombre = nombre;
            StockActual = stockActual;
            PrecioVenta = precioVenta;
        }
    }
}
