using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;

public class SqlServerExceptionMapper : IExceptionMapper
{
    private readonly ILogger<SqlServerExceptionMapper> _logger;

    public SqlServerExceptionMapper(ILogger<SqlServerExceptionMapper> logger)
    {
        _logger = logger;
    }

    public bool IsDuplicateEntry(Exception ex) =>
        ex is DbUpdateException { InnerException: SqlException { Number: 2627 } };

    public void LogException(Exception ex)
    {
        _logger.LogError(ex, "SQL Server-specific exception occurred.");
    }
}