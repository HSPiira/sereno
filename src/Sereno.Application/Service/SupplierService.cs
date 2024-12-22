using Sereno.Application.IRepository;
using Sereno.Application.IService;
using Sereno.Core;

namespace Sereno.Application.Service;

public class SupplierService :ISupplierService
{
    private readonly IGenericRepository<Supplier, Guid> _supplierRepository;
    public SupplierService(IGenericRepository<Supplier, Guid> supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    public async Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        return suppliers;
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _supplierRepository.AddAsync(supplier);
    }

    public async Task<Supplier> GetByIdAsync(Guid id)
    {
        return await _supplierRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supplierRepository.DeleteAsync(id);
    }
}