using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;

public class PostgresExceptionMapper : IExceptionMapper
{
    private readonly ILogger<PostgresExceptionMapper> _logger;

    public PostgresExceptionMapper(ILogger<PostgresExceptionMapper> logger)
    {
        _logger = logger;
    }

    public bool IsDuplicateEntry(Exception ex)
    {
        return ex is DbUpdateException { InnerException: PostgresException { SqlState: "23505" } };
    }

    public void LogException(Exception ex)
    {
        _logger.LogError(ex, "PostgreSQL-specific exception occurred.");
    }
}