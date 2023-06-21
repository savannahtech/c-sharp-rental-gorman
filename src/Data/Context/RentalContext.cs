using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class RentalContext : DbContext
{
    public RentalContext( DbContextOptions<RentalContext>options): base(options)
    {    
    } 
    
    /// <summary>
    /// Save changes
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified || e.State == EntityState.Added));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
                ((BaseEntity)entry.Entity).UpdatedOn = DateTime.Now;

            if (entry.State == EntityState.Added)
                ((BaseEntity)entry.Entity).CreatedOn = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    #region Configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Property>()
            .HasIndex(s => s.Reference)
            .IsUnique();*/

        modelBuilder.Entity<FeatureType>().HasData(
            new FeatureType
            {
                FeatureTypeId = 1,
                Code = "FT01",
                Name = "Apartment"
            });
    }

    #endregion

    #region Entities
    public DbSet<Property> Properties { get; set; }
    public DbSet<FeatureType> FeatureTypes { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
    public DbSet<PropertyFeature> PropertyFeatures { get; set; }
    public DbSet<PropertyLocation> PropertyLocations { get; set; }
    public DbSet<PropertyMedia> PropertyMedias { get; set; }
    public DbSet<PropertyRental> PropertyRentals { get; set; }
    public DbSet<PropertySale> PropertySales { get; set; }
    public DbSet<PropertyView> PropertyViews { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<BusinessDocument> BusinessDocuments { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<PropertyTenureType> PropertyTenureTypes { get; set; }
    public DbSet<PropertyLetType> PropertyLetTypes { get; set; }
    #endregion
    
}