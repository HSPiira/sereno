using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sereno.Infrastructure.Persistence;

public class AppDbContextDesignTimeDbContextFactory 
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlite();
        return new AppDbContext(builder.Options);
    }
}