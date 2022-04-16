using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Application.Dto.Pedido
{
    public class DetallePedidoDto
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Instrucciones { get; set; }

    }
}
