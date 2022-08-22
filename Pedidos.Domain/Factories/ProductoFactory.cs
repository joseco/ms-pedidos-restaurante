using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Model.Productos;
using System;

namespace Pedidos.Domain.Factories
{
    public class ProductoFactory : IProductoFactory
    {
        public Producto Create(Guid id, string nombre, decimal precioVenta, int stockActual)
        {
            return new Producto(id, nombre, precioVenta, stockActual);
        }
    }
}
