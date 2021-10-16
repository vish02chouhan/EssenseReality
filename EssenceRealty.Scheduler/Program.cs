using EssenceRealty.Repository;
using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Scheduler.Services;
using EssenceRealty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EssenceRealty.Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<VaultServicesConfig>(hostContext.Configuration.GetSection("VaultCrmService"));
              
                    //services.AddDbContext<EssenceRealtyContext>(opt =>
                    //   opt.UseSqlServer(hostContext.Configuration.GetSection("ConnectionStrings:EssenceConnex").Value)
                    //      .EnableSensitiveDataLogging()
                    //      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

                    services.AddPersistenceServices(hostContext.Configuration);

                    services.AddVaultApiClient(options => {
                        options.BaseAddress = hostContext.Configuration.GetSection("VaultCrmService:Url").Value;
                        options.ApiKey = Environment.GetEnvironmentVariable("VAULT_API_KEY");
                        options.BearerToken = Environment.GetEnvironmentVariable("VAULT_BEARER_TOKEN");

                    });

                    services.AddSingleton<VaultCrmProcessor, VaultCrmProcessor>();
                    services.AddSingleton<LogTransactionProcessor, LogTransactionProcessor>();
                    services.AddHostedService<Worker>();
                });
    }
}
