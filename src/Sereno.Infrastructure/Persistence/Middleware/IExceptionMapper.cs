namespace Sereno.Infrastructure.Persistence.Middleware;

public interface IExceptionMapper
{
    bool IsDuplicateEntry(Exception ex);
    void LogException(Exception ex);
}
