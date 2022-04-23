using System;

namespace Pedidos.Infraestructure.EF.ReadModel
{
    public class ProductoReadModel 
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
    }
}
