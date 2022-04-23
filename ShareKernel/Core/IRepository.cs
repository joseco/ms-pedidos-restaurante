using System.Threading.Tasks;

namespace ShareKernel.Core
{
    public interface IRepository<T, in TId> where T : AggregateRoot<TId>
    {
        Task<T> FindByIdAsync(TId id);

        Task CreateAsync(T obj);


    }
}
