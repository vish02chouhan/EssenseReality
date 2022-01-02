using EssenceRealty.Data.Identity;
using EssenceRealty.Repository;
using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ServiceProcessors;
using EssenceRealty.Scheduler.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace EssenceRealty.Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

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
                    services.AddIdentityServices(hostContext.Configuration);

                    services.AddVaultApiClient(options => {
                        options.BaseAddress = hostContext.Configuration.GetSection("VaultCrmService:Url").Value;
                        options.ApiKey = Environment.GetEnvironmentVariable("VAULT_API_KEY");
                        options.BearerToken = Environment.GetEnvironmentVariable("VAULT_BEARER_TOKEN");

                    });

                    services.AddSingleton<VaultCrmProcessor, VaultCrmProcessor>();

                    services.AddSingleton<LogTransactionProcessor, LogTransactionProcessor>();
                    services.AddTransient<IProcessEssence, SuburbsProcessor>();
                    services.AddTransient<IProcessEssence, PropertyTypeProcessor>();
                    services.AddTransient<IProcessEssence, PropertyClassProcessor>();
                    services.AddTransient<IProcessEssence, ContactsProcessor>();
                    services.AddTransient<IProcessEssence, PropertyProcessor>();
                    services.AddHostedService<Worker>();
                });
    }
}
