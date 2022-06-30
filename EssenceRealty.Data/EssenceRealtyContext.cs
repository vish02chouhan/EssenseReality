using EssenceRealty.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EssenceRealty.Data
{
    public class EssenceRealtyContext: IdentityDbContext<ApplicationUser>
    {
        public EssenceRealtyContext(DbContextOptions<EssenceRealtyContext> options)
            : base(options)
        {

        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyClass> PropertyClasses { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<PropertyFeatureGrouping> PropertyFeatureGroupings { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ContactStaff> ContactStaffs { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<FloorPlanFile> FloorPlanFiles { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<CrmEssenceLog> CrmEssenceLogs { get; set; }
        public DbSet<CrmEssenceTransaction> CrmEssenceTransactions { get; set; }
        public DbSet<EssenceObjectRequiredApproval> EssenceObjectRequiredApprovals { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PropertyContactStaff> PropertyContactStaffs { get; set; }
        public DbSet<PropertyFeatureProperty> PropertyFeatureProperties { get; set; }
        public DbSet<OpenHome> OpenHomes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyContactStaff>()
                    .HasKey(bc => new { bc.PropertyId, bc.ContactStaffId});
            modelBuilder.Entity<PropertyContactStaff>()
                .HasOne(bc => bc.Property)
                .WithMany(b => b.PropertyContactStaffs)
                .HasForeignKey(bc => bc.PropertyId);
            modelBuilder.Entity<PropertyContactStaff>()
                .HasOne(bc => bc.ContactStaff)
                .WithMany(c => c.PropertyContactStaffs)
                .HasForeignKey(bc => bc.ContactStaffId);

            modelBuilder.Entity<PropertyFeatureProperty>()
                    .HasKey(bc => new { bc.PropertyId, bc.PropertyFeatureId });
            modelBuilder.Entity<PropertyFeatureProperty>()
                .HasOne(bc => bc.Property)
                .WithMany(b => b.PropertyFeatureProperties)
                .HasForeignKey(bc => bc.PropertyId);
            modelBuilder.Entity<PropertyFeatureProperty>()
                .HasOne(bc => bc.PropertyFeature)
                .WithMany(c => c.PropertyFeatureProperties)
                .HasForeignKey(bc => bc.PropertyFeatureId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, LogLevel.Information);
        }
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
