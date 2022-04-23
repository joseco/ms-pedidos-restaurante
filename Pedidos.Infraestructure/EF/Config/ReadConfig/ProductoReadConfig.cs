using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Infraestructure.EF.ReadModel;

namespace Pedidos.Infraestructure.EF.Config.ReadConfig
{
    public class ProductoReadConfig : IEntityTypeConfiguration<ProductoReadModel>
    {
        public void Configure(EntityTypeBuilder<ProductoReadModel> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");


            builder.Property(x => x.PrecioVenta)
                .HasColumnName("precioVenta")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.StockActual)
                .HasColumnName("stockActual");

        }
    }
}
