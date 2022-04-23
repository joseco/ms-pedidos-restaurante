using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Event;
using Pedidos.Infraestructure.EF.Config.ReadConfig;
using Pedidos.Infraestructure.EF.ReadModel;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<PedidoReadModel> Pedido { set; get; }
        public virtual DbSet<ProductoReadModel> Producto { set; get; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new PedidoReadConfig();
            modelBuilder.ApplyConfiguration<PedidoReadModel>(pedidoConfig);
            modelBuilder.ApplyConfiguration<DetallePedidoReadModel>(pedidoConfig);

            var productoConfig = new ProductoReadConfig();
            modelBuilder.ApplyConfiguration<ProductoReadModel>(productoConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<PedidoCreado>();
            modelBuilder.Ignore<ItemPedidoAgregado>();
        }
    }
}
