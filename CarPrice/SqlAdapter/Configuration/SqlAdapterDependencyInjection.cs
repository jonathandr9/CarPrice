using CarPrice.Domain.Adapters;
using CarPrice.SqlAdapter;
using CarPrice.SqlAdapter.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SqlAdapterDependencyInjection
    {
        public static IServiceCollection AddCarPriceSqlAdapter
           (this IServiceCollection services,
           SqlAdapterConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(
                    nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(
                    nameof(configuration));

            services.AddScoped<
                ICarPhotoAdapter,
                CarPhotoAdapter>();

            services.AddSingleton(configuration);
            services.AddScoped
                (d => new SqlAdapterContext
                (configuration.SqlConnectionString));

            return services;
        }
    }
}
