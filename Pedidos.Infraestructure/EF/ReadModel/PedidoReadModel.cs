using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.ReadModel
{
    public class PedidoReadModel
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public string NroPedido { get; set; }

        public ICollection<DetallePedidoReadModel> Detalle { get; set; }


    }
}
