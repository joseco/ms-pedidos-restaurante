using MediatR;
using System;

namespace Pedidos.Application.UseCases.Command.Productos.CrearProducto
{
    public class CrearProductoCommand : IRequest<Guid>
    {
        public Guid ArticuloId { get; set; }
        public int StockActual { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public bool EsReceta { get; set; }

        private CrearProductoCommand() { }

        public CrearProductoCommand(Guid articuloId, int stockActual, decimal precioVenta, string nombre, string descripcion, bool esReceta = false)
        {
            ArticuloId = articuloId;
            StockActual = stockActual;
            PrecioVenta = precioVenta;
            Nombre = nombre;
            Descripcion = descripcion;
            EsReceta = esReceta;
        }
    }
}
