using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.MemoryRepository
{
    public class MemoryPedidoRepository : IPedidoRepository
    {
        private readonly MemoryDatabase _database;

        public MemoryPedidoRepository(MemoryDatabase database)
        {
            _database = database;
        }

        public Task CreateAsync(Pedido obj)
        {
            _database.Pedidos.Add(obj);
            return Task.CompletedTask;
        }

        public Task<Pedido> FindByIdAsync(Guid id)
        {
            return Task.FromResult(_database.Pedidos.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync(Pedido obj)
        {
            return Task.CompletedTask;
        }
    }
}
