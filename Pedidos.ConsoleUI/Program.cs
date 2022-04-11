using Pedidos.Domain.Model.Clientes;
using Pedidos.Domain.Model.Pedidos;
using Pedidos.Domain.Model.Productos;
using System;

namespace Pedidos.ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            Producto objProducto1 = new Producto("Pepsi 500ml", 8.5m, 10);
            Producto objProducto2 = new Producto("Hamburguesa simple", 18m, 100);

            Cliente objCliente = new Cliente("Jose Carlos Gutierrez");

            Pedido objPedido = new Pedido("12");
            objPedido.AgregarItem(objProducto1.Id, 2, objProducto1.PrecioVenta, "Fria");
            objPedido.AgregarItem(objProducto2.Id, 1, objProducto2.PrecioVenta, "");

            objPedido.ConsolidarPedido();


        }
    }
}
