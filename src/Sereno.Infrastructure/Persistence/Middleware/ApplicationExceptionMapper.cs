using Microsoft.Extensions.Logging;

namespace Sereno.Infrastructure.Persistence.Middleware;

public class ApplicationExceptionMapper : IExceptionMapper
{
    private readonly ILogger<ApplicationExceptionMapper> _logger;

    public ApplicationExceptionMapper(ILogger<ApplicationExceptionMapper> logger)
    {
        _logger = logger;
    }

    public bool IsDuplicateEntry(Exception ex) =>
        ex is InvalidOperationException &&
        ex.Message.Contains("Duplicate entry");

    public void LogException(Exception ex)
    {
        _logger.LogError(ex, "Application-level exception occurred.");
    }
}