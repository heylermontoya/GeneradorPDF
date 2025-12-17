using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BatchRecord.Domain.Ports;
using BatchRecord.Infrastructure.Adapters;
using BatchRecord.Infraestructure.Adapters;

namespace BatchRecord.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string stringConnection)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IQueryWrapper), typeof(DapperWrapper));
            services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
            // IDbConnection se registra en Program.cs para permitir selección dinámica por petición.

            return services;
        }
    }
}
