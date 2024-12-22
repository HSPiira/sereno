using Microsoft.EntityFrameworkCore;
using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Application.Shared;

public interface IAppDbContext
{
    DbSet<AppSetting> AppSettings { get; set; }
    DbSet<InventoryItem> InventoryItems { get; set; }
    DbSet<Drink> Drinks { get; set; }
    DbSet<Supplier> Suppliers { get; set; }
    Task<int> SaveChangesAsync();
}