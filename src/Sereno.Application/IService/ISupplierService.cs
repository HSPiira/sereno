using Sereno.Core;

namespace Sereno.Application.IService;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetAllSuppliers();
    Task AddAsync(Supplier supplier);
    Task<Supplier> GetByIdAsync(Guid id);
    Task UpdateAsync(Supplier supplier);
    Task DeleteAsync(Guid id);
}