using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Event;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Model.Productos;
using Pedidos.Infraestructure.EF.Config.WriteConfig;
using ShareKernel.Core;

namespace Pedidos.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new PedidoWriteConfig();
            modelBuilder.ApplyConfiguration<Pedido>(pedidoConfig);
            modelBuilder.ApplyConfiguration<DetallePedido>(pedidoConfig);

            var productoConfig = new ProductoWriteConfig();
            modelBuilder.ApplyConfiguration<Producto>(productoConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<PedidoCreado>();
            modelBuilder.Ignore<ItemPedidoAgregado>();
        }
    }
}
