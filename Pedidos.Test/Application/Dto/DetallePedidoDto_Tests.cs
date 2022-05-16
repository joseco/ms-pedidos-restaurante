using Pedidos.Application.Dto.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.Dto
{
    public class DetallePedidoDto_Tests
    {
        [Fact]
        public void DetallePedidoDto_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var cantidadTest = 5;
            decimal precioTest = new(40.0);
            var instruccionesTest = "Instrucciones de prueba";

            var detallePedido = new DetallePedidoDto();

            Assert.Equal(Guid.Empty, detallePedido.ProductoId);
            Assert.Equal(0, detallePedido.Cantidad);
            Assert.Equal(new decimal(0.0), detallePedido.Precio);
            Assert.Null(detallePedido.Instrucciones);

            detallePedido.Cantidad = cantidadTest;
            detallePedido.Precio = precioTest;
            detallePedido.Instrucciones = instruccionesTest;
            detallePedido.ProductoId = idTest;

            Assert.Equal(idTest, detallePedido.ProductoId);
            Assert.Equal(cantidadTest, detallePedido.Cantidad);
            Assert.Equal(precioTest, detallePedido.Precio);
            Assert.Equal(instruccionesTest, detallePedido.Instrucciones);
        }
    }
}
