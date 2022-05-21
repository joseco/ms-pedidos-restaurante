using System;

namespace Pedidos.Application.Dto.Producto
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

    }
}
