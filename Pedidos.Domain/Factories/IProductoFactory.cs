using Pedidos.Domain.Model.Productos;
using System;

namespace Pedidos.Domain.Factories
{
    public interface IProductoFactory
    {
        Producto Create(Guid id, string nombre, string descripcion, decimal precioVenta, int stockActual, bool esReceta = false);
    }
}
