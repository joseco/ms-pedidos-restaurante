using Pedidos.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.Services
{
    public class PedidoService_Tests
    {
        [Theory]
        [InlineData("ABC", true)]
        [InlineData("123", false)]
        [InlineData("456", false)]
        [InlineData("789", false)]
        [InlineData("111", false)]
        [InlineData("sss", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public async void GenerarPedido_CheckValidData(string expectedNroPedido, bool isEqual)
        {
            var pedidoService = new PedidoService();
            string nroPedido = await pedidoService.GenerarNroPedidoAsync();
            if (isEqual)
            {
                Assert.Equal(expectedNroPedido, nroPedido);
            }
            else
            {
                Assert.NotEqual(expectedNroPedido, nroPedido);
            }
        }

    }
}
