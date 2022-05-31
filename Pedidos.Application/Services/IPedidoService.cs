using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public interface IPedidoService 
    {
        Task<string> GenerarNroPedidoAsync();

    }
}
