using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Pedidos.Application.Dto.Pedido;
using Pedidos.Application.Services;
using Pedidos.Application.UseCases.Command.Pedidos.CrearPedido;
using Pedidos.Domain.Event;
using Pedidos.Domain.Factories;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF.Repository;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;

namespace Pedidos.Test.Application.UseCases.Handler
{
    public class CrearPedidoHandler_Test
    {
        private readonly Mock<IPedidoRepository> pedidoRepository;
        private readonly Mock<ILogger<CrearPedidoHandler>> logger;
        private readonly Mock<IPedidoService> pedidoService;
        private readonly Mock<IPedidoFactory> pedidoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private Pedido pedidoTest;
        private string nroPedidoTest = "ABC";
        private Guid guidTest = Guid.NewGuid();
        private List<DetallePedidoDto> detallePedidoTest = MockFactory.GetDetallePedido();


        public CrearPedidoHandler_Test()
        {
            pedidoRepository = new Mock<IPedidoRepository>();
            logger = new Mock<ILogger<CrearPedidoHandler>>();
            pedidoService = new Mock<IPedidoService>();
            pedidoFactory = new Mock<IPedidoFactory>();
            unitOfWork = new Mock<IUnitOfWork>();
            pedidoTest = new PedidoFactory().Create(nroPedidoTest);
        }

        [Fact]
        public void CrearPedidoHandler_HandleCorrectly()
        {
            pedidoService.Setup(pedidoService => pedidoService.GenerarNroPedidoAsync()).Returns(Task.FromResult(nroPedidoTest));
            pedidoFactory.Setup(pedidoFactory => pedidoFactory.Create(nroPedidoTest)).Returns(pedidoTest);
            var objHandler = new CrearPedidoHandler(
                pedidoRepository.Object,
                logger.Object,
                pedidoService.Object,
                pedidoFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new CrearPedidoCommand(
                detallePedidoTest
            );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            pedidoRepository.Verify(mock => mock.CreateAsync(IsAny<Pedido>()), Times.Once);
            unitOfWork.Verify(mock => mock.Commit(), Times.Once);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)pedidoTest.DomainEvents;
            Assert.Equal(4, domainEventList.Count);
            Assert.IsType<ItemPedidoAgregado>(domainEventList[0]);
            Assert.IsType<ItemPedidoAgregado>(domainEventList[1]);
            Assert.IsType<ItemPedidoAgregado>(domainEventList[2]);
            Assert.IsType<PedidoCreado>(domainEventList[3]);
        }
        [Fact]
        public void CrearPedidoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new CrearPedidoHandler(
               pedidoRepository.Object,
               logger.Object,
               pedidoService.Object,
               pedidoFactory.Object,
               unitOfWork.Object
           );
            var objRequest = new CrearPedidoCommand(
              detallePedidoTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear pedido"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
