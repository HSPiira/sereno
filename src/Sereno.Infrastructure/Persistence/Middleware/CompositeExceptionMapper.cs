namespace Sereno.Infrastructure.Persistence.Middleware;

public class CompositeExceptionMapper : IExceptionMapper
{
    private readonly IEnumerable<IExceptionMapper> _mappers;

    public CompositeExceptionMapper(IEnumerable<IExceptionMapper> mappers)
    {
        _mappers = mappers ?? throw new ArgumentNullException(nameof(mappers));
    }

    public bool IsDuplicateEntry(Exception ex)
    {
        return _mappers.Any(mapper => mapper.IsDuplicateEntry(ex));
    }

    public void LogException(Exception ex)
    {
        foreach (var mapper in _mappers)
        {
            mapper.LogException(ex);
        }
    }
}