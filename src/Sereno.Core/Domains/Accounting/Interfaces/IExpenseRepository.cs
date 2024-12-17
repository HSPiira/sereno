using Sereno.Core.Domains.Accounting.Entities;

namespace Sereno.Core.Domains.Accounting.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(Guid id);
}