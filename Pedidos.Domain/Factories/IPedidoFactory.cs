using Pedidos.Domain.Model.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Factories
{
    public interface IPedidoFactory
    {

        Pedido Create(string nroPedido);
    }
}
