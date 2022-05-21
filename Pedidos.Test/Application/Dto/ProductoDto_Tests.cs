using Pedidos.Application.Dto.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pedidos.Test.Application.Dto
{
    public class ProductoDto_Tests
    {
        [Fact]
        public void IsData_Valid()
        {
            var stockTest = 5;
            var idTest = Guid.NewGuid();
            decimal precioTest = new(40.0);
            var producto = new ProductoDto();

            Assert.Equal(Guid.Empty, producto.Id);
            Assert.Equal(0, producto.PrecioVenta);
            Assert.Equal(0, producto.StockActual);

            producto.Id = idTest;
            producto.PrecioVenta = precioTest;
            producto.StockActual = stockTest;

            Assert.Equal(idTest, producto.Id);
            Assert.Equal(precioTest, producto.PrecioVenta);
            Assert.Equal(stockTest, producto.StockActual);
        }
    }
}
