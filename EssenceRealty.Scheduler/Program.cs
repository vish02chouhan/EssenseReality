using EssenceRealty.Repository;
using EssenceRealty.Scheduler.Configurations;
using EssenseReality.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<VaultServicesConfig>(hostContext.Configuration.GetSection("VaultCrmService"));
              
                    //services.AddDbContext<EssenseRealityContext>(opt =>
                    //   opt.UseSqlServer(hostContext.Configuration.GetSection("ConnectionStrings:EssenceConnex").Value)
                    //      .EnableSensitiveDataLogging()
                    //      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

                    services.AddPersistenceServices(hostContext.Configuration);

                    services.AddVaultApiClient(options => options.BaseAddress = hostContext.Configuration.GetSection("VaultCrmService:Url").Value);

                    services.AddHostedService<Worker>();
                });
    }
}
