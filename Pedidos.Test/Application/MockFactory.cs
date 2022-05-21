using Pedidos.Application.Dto.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Test.Application
{
    public class MockFactory
    {
        public static List<DetallePedidoDto> GetDetallePedido()
        {
            return new List<DetallePedidoDto>()
            {
                new()
                {
                    Cantidad = 1,
                    Instrucciones = "Instrucciones Prod 1",
                    Precio = 10,
                    ProductoId = Guid.NewGuid()
                },
                new()
                {
                    Cantidad = 2,
                    Instrucciones = "Instrucciones Prod 2",
                    Precio = 20,
                    ProductoId = Guid.NewGuid()
                },
                new()
                {
                    Cantidad = 3,
                    Instrucciones = "Instrucciones Prod 3",
                    Precio = 30,
                    ProductoId = Guid.NewGuid()
                }
            };
        }
    }
}
