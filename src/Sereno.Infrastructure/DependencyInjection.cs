using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sereno.Application.Services;
using Sereno.Application.Services.Inventory;
using Sereno.Application.Services.Inventory.Implementations;
using Sereno.Application.Services.Inventory.Interfaces;
using Sereno.Application.Shared;
using Sereno.Core;
using Sereno.Core.Domains.Inventory;
using Sereno.Core.Domains.Inventory.Entities;
using Sereno.Infrastructure.Persistence;
using Sereno.Infrastructure.Repository;

namespace Sereno.Infrastructure;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(
                    typeof(AppDbContext).Assembly.FullName)), 
            ServiceLifetime.Transient);
        
        services.AddScoped<IGenericRepository<Supplier, Guid>, InMemoryRepository<Supplier, Guid>>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IGenericRepository<InventoryItem, Guid>, InMemoryRepository<InventoryItem, Guid>>();
        services.AddScoped<IInventoryService, InventoryService>();
    }
}