using Sereno.Core.Domains.Accounting.Entities;

namespace Sereno.Core.Domains.Accounting.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}