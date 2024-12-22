using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SereniLux.Application.Services.Inventory.Implementations;
using SereniLux.Application.Services.Inventory.Interfaces;
using SereniLux.Core.Domains.Inventory.Interfaces;
using SereniLux.Infrastructure.Persistence;
using SereniLux.Infrastructure.Repositories.Inventory;

namespace SereniLux.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(
                    typeof(AppDbContext).Assembly.FullName)), 
            ServiceLifetime.Transient);

        services.AddScoped<AppDbContext>();
        services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<SupplierService>();
        return services;
    }
}