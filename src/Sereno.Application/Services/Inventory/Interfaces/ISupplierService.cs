using Sereno.Core;
using Sereno.Core.Domains.Inventory;
using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Application.IService;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetAllSuppliers();
    Task AddAsync(Supplier supplier);
    Task<Supplier> GetByIdAsync(Guid id);
    Task UpdateAsync(Supplier supplier);
    Task DeleteAsync(Guid id);
}