using Microsoft.Extensions.Logging;
using Moq;
using Pedidos.Application.UseCases.Command.Productos.CrearProducto;
using Pedidos.Domain.Event;
using Pedidos.Domain.Factories;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.UseCases.Handler
{
    public class CrearProductoHandler_Test
    {
        private readonly Mock<IProductoRepository> productoRepository;
        private readonly Mock<ILogger<CrearProductoHandler>> logger;
        private readonly Mock<IProductoFactory> productoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private int stockActualTest = 5;
        private decimal precioActualTest = new decimal(40.0);
        private string nombreProductoTest = "Test";
        private Producto productoTest;

        public CrearProductoHandler_Test()
        {
            productoRepository = new Mock<IProductoRepository>();
            logger = new Mock<ILogger<CrearProductoHandler>>();
            productoFactory = new Mock<IProductoFactory>();
            unitOfWork = new Mock<IUnitOfWork>();
            productoTest = new ProductoFactory().Create(nombreProductoTest, precioActualTest, stockActualTest);

        }
        [Fact]
        public void CrearProductoHandler_HandleCorrectly()
        {


            productoFactory.Setup(factory => factory.Create(nombreProductoTest, precioActualTest, stockActualTest))
                .Returns(productoTest);

            var objHandler = new CrearProductoHandler(
                productoRepository.Object,
                logger.Object,
                productoFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new CrearProductoCommand(
               stockActualTest, precioActualTest, nombreProductoTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)productoTest.DomainEvents;
            Assert.Single(domainEventList);
            Assert.IsType<ProductoCreado>(domainEventList[0]);
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new CrearProductoHandler(
                productoRepository.Object,
                logger.Object,
                productoFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new CrearProductoCommand(
               stockActualTest, precioActualTest, nombreProductoTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear producto"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
