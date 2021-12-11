using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Repository.Repositories;
using EssenceRealty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EssenceRealty.Repository
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EssenceRealtyContext>(options =>
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration.GetConnectionString("EssenceConnex")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICrmEssenceLogRepository), typeof(CrmEssenceLogRepository));
            services.AddScoped(typeof(ISubhurbRepository), typeof(SubhurbRepository));
            services.AddScoped(typeof(IStateRepository), typeof(StateRepository));
            services.AddScoped(typeof(ICrmEssenceTransactionRepository), typeof(CrmEssenceTransactionRepository));
            services.AddScoped(typeof(IPropertyClassRepository), typeof(PropertyClassRepository));
            services.AddScoped(typeof(IPropertyTypeRepository), typeof(PropertyTypeRepository));
            services.AddScoped(typeof(IPhoneNumberRepository), typeof(PhoneNumberRepository));
            services.AddScoped(typeof(IPhotoRepository), typeof(PhotoRepository));
            services.AddScoped(typeof(IContactStaffRepository), typeof(ContactStaffRepository));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(IPropertyRepository), typeof(PropertyRepository));
            services.AddScoped(typeof(IPropertyContactStaffRepository), typeof(PropertyContactStaffRepository));
            services.AddScoped(typeof(IEssenceObjectRequiredApprovalRepository), typeof(EssenceObjectRequiredApprovalRepository));
            services.AddScoped(typeof(IPropertyFeatureGroupingRepository), typeof(PropertyFeatureGroupingRepository));
            services.AddScoped(typeof(IPropertyFeatureRepository), typeof(PropertyFeatureRepository));
            services.AddScoped(typeof(IPropertyFeaturePropertyRepository), typeof(PropertyFeaturePropertyRepository));
            services.AddScoped(typeof(IEnquiryRepository), typeof(EnquiryRepository));
            services.AddScoped(typeof(IFloorPlanRepository), typeof(FloorPlanRepository));
            services.AddScoped(typeof(IOpenHomeRepository), typeof(OpenHomeRepository));

            return services;
        }
    }
}
