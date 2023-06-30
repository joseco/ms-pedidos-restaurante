using Pedidos.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Domain
{
    public class ProductoFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            string nombreTest = "Coca-cola";
            string descripcionTest = "Descripcion coca-cola";
            decimal precioTest = 50;
            int stockTest = 5;
            var factory = new ProductoFactory();
            var producto = factory.Create(Guid.NewGuid(), nombreTest, descripcionTest, 50, 5);
            
            Assert.NotNull(producto);
            Assert.Equal(nombreTest, producto.Nombre);
            Assert.Equal(descripcionTest, producto.Descripcion);
            Assert.Equal(precioTest, producto.PrecioVenta.Value);
            Assert.Equal(stockTest, producto.StockActual.Value);
        }
    }
}
