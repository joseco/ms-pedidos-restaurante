using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.Config.ReadConfig
{
    public class PedidoReadConfig : IEntityTypeConfiguration<PedidoReadModel>,
        IEntityTypeConfiguration<DetallePedidoReadModel>
    {
        public void Configure(EntityTypeBuilder<PedidoReadModel> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroPedido)
                .HasColumnName("nroPedido")
                .HasMaxLength(6);

            builder.Property(x => x.Total)
                .HasColumnName("total")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.Detalle)
                .WithOne(x => x.Pedido);

        }

        public void Configure(EntityTypeBuilder<DetallePedidoReadModel> builder)
        {
            builder.ToTable("DetallePedido");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Instrucciones)
                .HasColumnName("instrucciones")
                .HasMaxLength(500);

            builder.Property(x => x.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.SubTotal)
                .HasColumnName("subTotal")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.Cantidad)
                .HasColumnName("cantidad");
        }
    }
}
