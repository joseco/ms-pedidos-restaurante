using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        public Task<string> GenerarNroPedidoAsync() => Task.FromResult("ABC");
    }
}
