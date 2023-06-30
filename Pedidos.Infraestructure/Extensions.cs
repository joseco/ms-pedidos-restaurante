using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Application;
using Pedidos.Application.UseCases.Consumers;
using Pedidos.Domain.Repositories;
using Pedidos.Infraestructure.EF;
using Pedidos.Infraestructure.EF.Contexts;
using Pedidos.Infraestructure.EF.Repository;
using System.Reflection;

namespace Pedidos.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = 
                configuration.GetConnectionString("PedidoDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => 
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => 
                context.UseSqlServer(connectionString));

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            AddRabbitMq(services, configuration);

            return services;
        }


        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config =>
            {
                config.AddConsumer<ArticuloCreadoConsumer>().Endpoint(endpoint => endpoint.Name = ArticuloCreadoConsumer.QueueName);
                config.AddConsumer<StockArticuloActualizadoConsumer>().Endpoint(endpoint => endpoint.Name = StockArticuloActualizadoConsumer.QueueName);

                config.UsingRabbitMq((context, cfg) =>
                {
                    var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);

                    cfg.ReceiveEndpoint(ArticuloCreadoConsumer.QueueName, endpoint =>
                    {
                        endpoint.ConfigureConsumer<ArticuloCreadoConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(StockArticuloActualizadoConsumer.QueueName, endpoint =>
                    {
                        endpoint.ConfigureConsumer<StockArticuloActualizadoConsumer>(context);
                    });
                });
            });
        }

    }
}
