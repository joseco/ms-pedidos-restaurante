﻿using Pedidos.Domain.Model.Productos;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Pedidos.Domain.Repositories
{
    public interface IProductoRepository : IRepository<Producto, Guid>
    {
        Task UpdateAsync(Producto obj);

        Task RemoveAsync(Producto obj);

    }
}
