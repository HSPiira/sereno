namespace Sereno.Application.Shared;

public interface IGenericRepository<T, in TKey> where T : class
{ 
    Task AddAsync(T entity); 
    Task<T> GetByIdAsync(TKey id); 
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T entity); 
    Task DeleteAsync(TKey id);
}