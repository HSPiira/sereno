using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Core.Domains.Inventory.Interfaces;

public interface IInventoryRepository
{
    Task<InventoryItem> GetByIdAsync(Guid id);
    Task<IEnumerable<InventoryItem>> GetAllAsync();
    Task AddAsync(InventoryItem inventoryItem);
    Task UpdateAsync(InventoryItem inventoryItem);
    Task DeleteAsync(Guid id);
}