using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF;
using Pedidos.Infraestructure.EF.Repository;
using Pedidos.Infraestructure.MemoryRepository;

namespace Pedidos.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TODO: Eliminar despues. Solo para proposito de pruebas
            services.AddSingleton<MemoryDatabase>();

            services.AddScoped<IPedidoRepository, MemoryPedidoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
