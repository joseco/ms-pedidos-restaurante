using Pedidos.Application.UseCases.Command.Productos.CrearProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.UseCases.Command
{
    public class CrearProductoCommand_Test
    {
        [Fact]
        public void CrearProductoCommand_DataValid()
        {
            var stockActualTest = 5;
            var precioActualTest = new decimal(40.0);
            var nombreProductoTest = "Test";
            var command = new CrearProductoCommand(stockActualTest, precioActualTest, nombreProductoTest);

            Assert.Equal(stockActualTest, command.StockActual);
            Assert.Equal(precioActualTest, command.PrecioVenta);
            Assert.Equal(nombreProductoTest, command.Nombre);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (CrearProductoCommand)Activator.CreateInstance(typeof(CrearProductoCommand), true);
            Assert.Null(command.Nombre);
            Assert.Equal(0, command.StockActual);
            Assert.Equal(new decimal(0.0), command.PrecioVenta);
        }

    }
}
