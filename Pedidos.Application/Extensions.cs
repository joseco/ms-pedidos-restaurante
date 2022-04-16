using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Domain.Factories;

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
