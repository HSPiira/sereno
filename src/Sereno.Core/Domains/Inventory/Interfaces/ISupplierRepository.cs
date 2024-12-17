using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Core.Domains.Inventory.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier> GetByIdAsync(Guid id);
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task AddAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
    Task DeleteAsync(Guid id);
}