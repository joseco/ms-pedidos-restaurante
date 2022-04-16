using Pedidos.Domain.Model.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.MemoryRepository
{
    public class MemoryDatabase
    {
        private readonly List<Pedido> _pedidos;

        public List<Pedido> Pedidos
        {
            get { return _pedidos; }
        }

        public MemoryDatabase()
        {
            _pedidos = new List<Pedido>();
        }

    }
}
