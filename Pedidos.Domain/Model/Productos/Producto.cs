using Pedidos.Domain.Model.ValueObjects;
using Pedidos.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Pedidos.Domain.Model.Productos
{
    public class Producto : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }

        public PrecioValue PrecioVenta { get; private set; }

        public CantidadValue StockActual { get; private set; }

        private Producto()
        {
            PrecioVenta = 0;
            StockActual = 0;
        }

        public Producto(string nombre, PrecioValue precioVenta, CantidadValue stockActual)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            PrecioVenta = precioVenta;
            StockActual = stockActual;
        }

        public void ReducirStock(CantidadValue cantidad)
        {
            int stockResultante = StockActual - cantidad;
            if (stockResultante < 0)
            {
                throw new BussinessRuleValidationException("La cantidad de stock actual es insuficiente");
            }
            StockActual = stockResultante;
        }

    }
}
