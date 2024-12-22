using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;

namespace Sereno.Infrastructure.Persistence.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IExceptionMapper _exceptionMapper;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IExceptionMapper exceptionMapper)
    {
        _next = next;
        _logger = logger;
        _exceptionMapper = exceptionMapper;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex) when (_exceptionMapper.IsDuplicateEntry(ex))
        {
            if (context.Response.HasStarted) return;
            _logger.LogWarning(ex, "Duplicate entry exception caught: {Message}", ex.Message);
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Duplicate entry detected."
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            if (context.Response.HasStarted) return;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                message = "An internal error occurred."
            });
            _logger.LogError(ex, "An unhandled exception occurred.");
        }
    }
}