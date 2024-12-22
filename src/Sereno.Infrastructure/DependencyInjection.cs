using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sereno.Application.Services.Inventory.Implementations;
using Sereno.Application.Services.Inventory.Interfaces;
using Sereno.Application.Shared;
using Sereno.Core.Domains.Inventory.Entities;
using Sereno.Infrastructure.Persistence;
using Sereno.Infrastructure.Persistence.Middleware;
using Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;
using Sereno.Infrastructure.Repository;

namespace Sereno.Infrastructure;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Register AppDbContext with default Scoped lifetime
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            )
        );

        // Register repositories
        services.AddScoped<IGenericRepository<Supplier, Guid>, InMemoryRepository<Supplier, Guid>>();
        services.AddScoped<IGenericRepository<InventoryItem, Guid>, InMemoryRepository<InventoryItem, Guid>>();

        // Register services
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IInventoryService, InventoryService>();

        // Register exception mappers
        services.AddSingleton<SqliteExceptionMapper>();
        services.AddSingleton<PostgresExceptionMapper>();
        services.AddSingleton<SqlServerExceptionMapper>();
        services.AddSingleton<ApplicationExceptionMapper>();

        // Register composite exception mapper
        services.AddSingleton<IExceptionMapper>(sp => 
            new CompositeExceptionMapper(new List<IExceptionMapper>
            {
                sp.GetRequiredService<SqliteExceptionMapper>(),
                sp.GetRequiredService<PostgresExceptionMapper>(),
                sp.GetRequiredService<SqlServerExceptionMapper>(),
                sp.GetRequiredService<ApplicationExceptionMapper>()
            })
        );
    }
}