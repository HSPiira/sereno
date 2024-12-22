using Microsoft.EntityFrameworkCore;
using Sereno.Application.Shared;
using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext, IAppDbContext
{
    #region Ctor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Suppliers = Set<Supplier>();
        Drinks = Set<Drink>();
        AppSettings = Set<AppSetting>();
        InventoryItems = Set<InventoryItem>();
    }
    #endregion

    #region DbSet
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<AppSetting> AppSettings { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    #endregion
    
    #region Methods
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (!typeof(IEntity).IsAssignableFrom(clrType)) continue;
            var method = GetType()
                .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.MakeGenericMethod(clrType);

            method?.Invoke(null, [modelBuilder]);
        }

        modelBuilder.Entity<Supplier>()
            .HasIndex(s => new { s.Name, s.Address })
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");
        
        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(i => new {i.Name, i.Category}).IsUnique();
            entity.OwnsOne(e => e.StockLevel, stockLevel =>
            {
                stockLevel.Property(sl => sl.Amount).HasColumnName("StockLevel");
            });
        });
        
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(i => new {i.Name, i.Category}).IsUnique();
            entity.OwnsOne(e => e.Price, money =>
            {
                money.Property(m => m.Amount).HasColumnName("Price");
            });
        });

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateTimeStamps();
        return base.SaveChanges();
    }

    private void UpdateTimeStamps()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = null;
                    entry.Entity.IsDeleted = false;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                    entry.Entity.IsDeleted = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : class, IEntity
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
    }
}