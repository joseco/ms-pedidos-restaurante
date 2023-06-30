using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Model.Productos;
using System;

namespace Pedidos.Domain.Factories
{
    public class ProductoFactory : IProductoFactory
    {
        public Producto Create(Guid id, string nombre,  string descripcion, decimal precioVenta, int stockActual, bool esReceta = false)
        {
            return new Producto(id, nombre, descripcion, precioVenta, stockActual, esReceta);
        }
    }
}
