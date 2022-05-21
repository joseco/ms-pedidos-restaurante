using Pedidos.Application.Dto.Pedido;
using Pedidos.Application.UseCases.Command.Pedidos.CrearPedido;
using System;
using System.Collections.Generic;
using Xunit;

namespace Pedidos.Test.Application.UseCases.Command
{
    public class CrearPedidoCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var pedidoListTest = MockFactory.GetDetallePedido();
            var command = new CrearPedidoCommand(pedidoListTest);

            Assert.Equal(3, command.Detalle.Count);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (CrearPedidoCommand)Activator.CreateInstance(typeof(CrearPedidoCommand), true);
            Assert.Null(command.Detalle);
        }


        
    }
}
