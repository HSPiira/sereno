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
        services.AddDbContext(configuration);
        services.RegisterRepositories();
        services.RegisterServices();
        services.RegisterExceptionMappers();
        services.RegisterCompositeExceptionMapper();
    }

    #region DbContext
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            )
        );
    }
    #endregion

    #region Register Repositories
    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Supplier, Guid>, InMemoryRepository<Supplier, Guid>>();
        services.AddScoped<IGenericRepository<InventoryItem, Guid>, InMemoryRepository<InventoryItem, Guid>>();
    }
    #endregion

    #region Register Services
    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IInventoryService, InventoryService>();
    }
    #endregion

    #region Register Exception Mappers
    private static void RegisterExceptionMappers(this IServiceCollection services)
    {
        services.AddSingleton<SqliteExceptionMapper>();
        services.AddSingleton<PostgresExceptionMapper>();
        services.AddSingleton<SqlServerExceptionMapper>();
        services.AddSingleton<ApplicationExceptionMapper>();
    }
    #endregion

    #region Composite Exception Mapper
    private static void RegisterCompositeExceptionMapper(this IServiceCollection services)
    {
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
    #endregion
}