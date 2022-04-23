using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
