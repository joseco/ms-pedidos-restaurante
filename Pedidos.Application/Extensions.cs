using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application.Services;
using Pedidos.Domain.Factories;
using System.Reflection;

namespace Pedidos.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoFactory, PedidoFactory>();



            return services;
        }

    }
}
