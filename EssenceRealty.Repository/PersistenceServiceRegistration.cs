using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Repository.Repositories;
using EssenseReality.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EssenceRealty.Repository
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EssenseRealityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EssenceConnex")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICrmEssenceLogRepository), typeof(CrmEssenceLogRepository));

            return services;
        }
    }
}
