using Pedidos.Domain.Model.Pedidos;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Model.Productos
{
    public class Producto : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }

        public decimal Precio { get; set; }

        public int StockActual { get; set; }

        public Producto()
        {
            Id = Guid.NewGuid();
        }
    }
}
