using Pedidos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task Commit()
        {
            return Task.CompletedTask;
        }
    }
}
