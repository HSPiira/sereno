namespace Sereno.Infrastructure.Persistence.Middleware.DbExceptionMapper;

public interface IExceptionMapper
{
    bool IsDuplicateEntry(Exception ex);
    void LogException(Exception ex);
}
