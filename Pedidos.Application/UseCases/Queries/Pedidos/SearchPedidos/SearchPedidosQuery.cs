using MediatR;
using Pedidos.Application.Dto.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Queries.Pedidos.GetPedidosCancelados
{
    public class SearchPedidosQuery : IRequest<ICollection<PedidoDto>>
    {
        public string NroPedido { get; set; }
    }
}
