using Microsoft.EntityFrameworkCore;
using Sereno.Application.Shared;
using Sereno.Core.Common;
using Sereno.Infrastructure.Persistence;

namespace Sereno.Infrastructure.Repository;

public class InMemoryRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
{
    private readonly AppDbContext _dbContext;
    public InMemoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(TKey id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity ?? throw new KeyNotFoundException($"Item with id {id} not found");
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        switch (entity)
        {
            case null:
                throw new InvalidOperationException($"Entity with ID {id} not found.");
            case IEntity softDeletableEntity:
                softDeletableEntity.IsDeleted = true;
                _dbContext.Set<T>().Update((T)softDeletableEntity); // Mark the entity as modified
                await _dbContext.SaveChangesAsync();
                break;
            default:
                throw new InvalidOperationException("Entity does not support soft delete.");
        }
    }
    
    public async Task RestoreAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        switch (entity)
        {
            case null:
                throw new InvalidOperationException($"Entity with ID {id} not found.");
            case IEntity softDeletableEntity:
                softDeletableEntity.IsDeleted = false;
                _dbContext.Set<T>().Update((T)softDeletableEntity);
                await _dbContext.SaveChangesAsync();
                break;
            default:
                throw new InvalidOperationException("Entity does not support restore operation.");
        }
    }

}