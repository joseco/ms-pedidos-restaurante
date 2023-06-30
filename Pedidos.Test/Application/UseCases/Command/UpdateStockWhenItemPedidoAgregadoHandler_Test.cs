using Moq;
using Pedidos.Application.UseCases.Command.Productos.UpdateStockWhenItemPedidoAgregado;
using Pedidos.Domain.Event;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.UseCases.Command
{
    public class UpdateStockWhenItemPedidoAgregadoHandler_Test
    {
        private readonly Mock<IProductoRepository> productoRepository;
        public UpdateStockWhenItemPedidoAgregadoHandler_Test()
        {
            productoRepository = new Mock<IProductoRepository>();
        }

        [Fact]
        public void Handle_Correctly()
        {
            var productoIdTest = Guid.NewGuid();
            decimal precioTest = new decimal(10.0);
            int cantidadValue = 1;

            var idTest = Guid.NewGuid();
            var nombreProdTest = "Coca-Cola";
            var descripcion = "";
            var precioVentaTest = new decimal(3.0);
            var stockActualTest = 4;
            var esReceta = false;
            var productoTest = new Producto(idTest, nombreProdTest, descripcion, precioVentaTest, stockActualTest, esReceta);
            var tcs = new CancellationTokenSource(1000);

            productoRepository.Setup(mock => mock.FindByIdAsync(productoIdTest))
                .Returns(Task.FromResult(productoTest));

            var handler = new UpdateStockWhenItemPedidoAgregadoHandler(productoRepository.Object);
            var objRequest = new ItemPedidoAgregado(
                    productoIdTest, precioTest, cantidadValue
            );
            var result = handler.Handle(objRequest, tcs.Token);

            Assert.Equal(3, (int)productoTest.StockActual);
        }
    }
}
