using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Model.ValueObjects;
using Pedidos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Infraestructure.EF.Config.WriteConfig
{
    public class ProductoWriteConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.PrecioVenta)
                .HasConversion(precioConverter)
                .HasColumnName("precioVenta")
                .HasPrecision(12, 2);

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
               cantidadValue => cantidadValue.Value,
               cantidad => new CantidadValue(cantidad)
           );

            builder.Property(x => x.StockActual)
                .HasConversion(cantidadConverter)
                .HasColumnName("stockActual");
        }
    }
}
