using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EssenseReality.Data
{
    public class EssenseRealityContext:DbContext
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
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<CrmEssenceLog> CrmEssenceLogs { get; set; }
        public DbSet<CrmEssenceTransaction> CrmEssenceTransactions { get; set; }
    }
}
