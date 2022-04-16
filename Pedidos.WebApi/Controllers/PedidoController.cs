using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Dto.Pedido;
using Pedidos.Application.UseCases.Command.Pedidos.CrearPedido;
using Pedidos.Application.UseCases.Queries.Pedidos.GetPedidoById;
using System;
using System.Threading.Tasks;

namespace Pedidos.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearPedidoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetPedidoByIdQuery command)
        {
            PedidoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
