using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.ReadModel
{
    public class DetallePedidoReadModel
    {
        public Guid Id { get; set; }
        public string Instrucciones { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

        public PedidoReadModel Pedido { get; set; }

        public ProductoReadModel Producto { get; set; }

    }
}
