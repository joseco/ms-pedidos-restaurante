using Pedidos.Domain.Model.Productos;

namespace Pedidos.Domain.Factories
{
    public interface IProductoFactory
    {
        Producto Create(string nombre, decimal precioVenta, int stockActual);
    }
}
