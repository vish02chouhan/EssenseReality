using EssenceRealty.Scheduler.ExternalServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVaultApiClient(this IServiceCollection services, 
            Action<VaultApiClientOptions> setupAction)
        {
            services.AddHttpClient<VaultApiClient, VaultApiClient>();

            services.AddOptions();
            services.Configure(setupAction);

            return services;
        }
    }
}
