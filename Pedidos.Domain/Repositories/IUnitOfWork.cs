using System.Threading.Tasks;

namespace Pedidos.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
