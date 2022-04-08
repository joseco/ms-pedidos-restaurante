using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Model.Pedidos
{
    public class DetallePedido : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
        public Guid ProductoId { get; private set; }
        public string Instrucciones { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Precio { get; private set; }
        public decimal SubTotal { get; private set; }

        internal DetallePedido(Guid productoId, string instrucciones,
            int cantidad, decimal precio)
        {
            Id = Guid.NewGuid();
            ProductoId = productoId;
            Instrucciones = instrucciones;
            Cantidad = cantidad;
            Precio = precio;
            SubTotal = precio * cantidad;
        }

    }
}
