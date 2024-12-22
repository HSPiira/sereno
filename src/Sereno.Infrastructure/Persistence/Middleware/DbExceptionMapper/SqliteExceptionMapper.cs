using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;

public class SqliteExceptionMapper : IExceptionMapper
{
    private readonly ILogger<SqliteExceptionMapper> _logger;

    public SqliteExceptionMapper(ILogger<SqliteExceptionMapper> logger)
    {
        _logger = logger;
    }

    public bool IsDuplicateEntry(Exception ex) =>
        ex is DbUpdateException { InnerException: SqliteException { SqliteErrorCode: 19 } };

    public void LogException(Exception ex)
    {
        _logger.LogError(ex, "SQLite-specific exception occurred.");
    }
}