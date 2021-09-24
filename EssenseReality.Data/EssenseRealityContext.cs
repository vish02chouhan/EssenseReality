using EssenseReality.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EssenseReality.Data
{
    ////public class DomainEntityBase
    ////{
    ////    [Key]
    ////    public int Id { get; set; }
    ////}
    //public static class DbContextExtensions
    //{
    //    //public static void AddOrUpdate<T>(this DbSet<T> dbSet, IEnumerable<T> records)
    //    //    where T : DomainEntityBase
    //    //{
    //    //    foreach (var data in records)
    //    //    {
    //    //        var exists = dbSet.AsNoTracking().Any(x => x.Id == data.Id);
    //    //        if (exists)
    //    //        {
    //    //            dbSet.Update(data);
    //    //            continue;
    //    //        }
    //    //        dbSet.Add(data);
    //    //    }
    //    //}
    //    //public static TEntity AddOrUpdate<TEntity>(this DbSet<TEntity> dbSet, DbContext context, Func<TEntity, object> identifier, TEntity entity) where TEntity : class
    //    //{
    //    //    //foreach (var entity in entities)
    //    //    //{
    //    //        TEntity result = dbSet.Find(identifier.Invoke(entity));
    //    //        if (result != null)
    //    //        {
    //    //            context.Entry(result).CurrentValues.SetValues(entity);
    //    //            dbSet.Update(result);
    //    //        return result;
    //    //    }
    //    //        else
    //    //        {
    //    //            dbSet.Add(entity);
    //    //        return entity;
    //    //    }
    //    //    //}
    //    //    //return dbSet;
    //    //}

    //}
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
        public DbSet<Suburb> Suburb { get; set; }
        public DbSet<State> State { get; set; }

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

        //public static IEnumerable<TEntity> AddOrUpdate<TEntity>(this DbSet<TEntity> dbSet, DbContext context, Func<TEntity, object> identifier, IEnumerable<TEntity> entities) where TEntity : class
        //{
        //    foreach (var entity in entities)
        //    {
        //        TEntity result = dbSet.Find(identifier.Invoke(entity));
        //        if (result != null)
        //        {
        //            context.Entry(result).CurrentValues.SetValues(entity);
        //            dbSet.Update(result);
        //            //return result;
        //        }
        //        else
        //        {
        //            dbSet.Add(entity);
        //            //return entity;
        //        }
        //    }
        //    return dbSet;
        //}
    }
}
