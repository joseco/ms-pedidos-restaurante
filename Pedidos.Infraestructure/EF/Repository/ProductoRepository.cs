using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public readonly DbSet<Producto> _productos;

        public ProductoRepository(WriteDbContext context)
        {
            _productos = context.Producto;
        }
        public async Task CreateAsync(Producto obj)
        {
            await _productos.AddAsync(obj);
        }

        public async Task<Producto> FindByIdAsync(Guid id)
        {
            return await _productos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Producto obj)
        {
            _productos.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Producto obj)
        {
            _productos.Update(obj);
            return Task.CompletedTask;
        }
    }
}
