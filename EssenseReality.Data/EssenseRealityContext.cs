using EssenseReality.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EssenseReality.Data
{
    public class EssenseRealityContext: IdentityDbContext
    {
        public EssenseRealityContext(DbContextOptions<EssenseRealityContext> options)
            : base(options)
        {

        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyClass> PropertyClasses { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<ContactStaff> ContactStaffs { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<CrmEssenceLog> CrmEssenceLogs { get; set; }
        public DbSet<CrmEssenceTransaction> CrmEssenceTransactions { get; set; }
        public DbSet<EssenceObjectRequiredApproval> EssenceObjectRequiredApprovals { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<WhoFields>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                      //  entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                      //  entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
