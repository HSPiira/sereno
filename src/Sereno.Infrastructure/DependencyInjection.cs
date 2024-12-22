using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sereno.Application.IRepository;
using Sereno.Application.IService;
using Sereno.Application.Service;
using Sereno.Core;
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
    }
}