using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public readonly DbSet<Pedido> _pedidos;

        public PedidoRepository(WriteDbContext context)
        {
            _pedidos = context.Pedido;
        }

        public async Task CreateAsync(Pedido obj)
        {
            await _pedidos.AddAsync(obj);
        }

        public async Task<Pedido> FindByIdAsync(Guid id)
        {
            return await _pedidos.Include("_detalle")
                    .SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Pedido obj)
        {
            _pedidos.Update(obj);

            return Task.CompletedTask;
        }
    }
}
