using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Sereno.Infrastructure;
using Sereno.Infrastructure.Persistence;
using Sereno.Infrastructure.Persistence.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddPersistence(builder.Configuration);
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlite("Data Source=suppliers.db"));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();  // Apply migrations at startup
    Console.WriteLine("Database migrations applied successfully.");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();