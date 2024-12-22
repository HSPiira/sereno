using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Application.Services.Inventory.Interfaces;

public interface IInventoryService
{
    Task<IEnumerable<InventoryItem>> GetAllInventoryItems();
    Task AddAsync(InventoryItem inventoryItem);
    Task<InventoryItem> GetByIdAsync(Guid id);
    Task UpdateAsync(InventoryItem inventoryItem);
    Task DeleteAsync(Guid id);
    Task<InventoryItem> RestockAsync(Guid id, int quantity);
    Task<InventoryItem> DeductStockAsync(Guid id, int quantity);
}