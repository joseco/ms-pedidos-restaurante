using Pedidos.Domain.Event;
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

        public bool EsReceta { get; private set; }

        public string Descripcion { get; private set; }

        private Producto()
        {
            PrecioVenta = 0;
            StockActual = 0;
        }

        public Producto(Guid id, string nombre, string descripcion, PrecioValue precioVenta, CantidadValue stockActual, bool esReceta = false)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
            StockActual = stockActual;
            EsReceta = esReceta;
        }
       

        public void UpdateStock(CantidadValue nuevaCantidad)
        {
            if (EsReceta)
            {
                return;
            }

            if (nuevaCantidad < 0)
            {
                throw new BussinessRuleValidationException("La cantidad de stock actual es insuficiente");
            }
            StockActual = nuevaCantidad;
        }

    }
}
