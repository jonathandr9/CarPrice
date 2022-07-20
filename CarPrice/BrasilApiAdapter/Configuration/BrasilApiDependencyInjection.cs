using BrasilApiAdapter;
using BrasilApiAdapter.Clients;
using CarPrice.Domain.Adapters;
using Refit;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BrasilApiServiceCollectionExtensions
    {
        public static IServiceCollection AddBrasilApiAdapter(
            this IServiceCollection services,
            BrasilApiAdapterConfiguration brasilApiAdapterConfiguration
            )
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (brasilApiAdapterConfiguration == null)
            {
                throw new ArgumentNullException
                    (nameof(brasilApiAdapterConfiguration));
            }

            services.AddSingleton
                (brasilApiAdapterConfiguration);

            services.AddRefitClient<IBrasilApiClient>()
               .ConfigureHttpClient(
                   c => c.BaseAddress = new Uri(brasilApiAdapterConfiguration
                        .ApiUrlBase));

            services.AddScoped<
                IBrasilApiAdapter,
                BrasilApi>();

            return services;
        }
    }
}