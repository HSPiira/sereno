using Sereno.Application.Services.Inventory.Interfaces;
using Sereno.Application.Shared;
using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Application.Services.Inventory.Implementations;

public class InventoryService : IInventoryService
{
    private readonly IGenericRepository<InventoryItem, Guid> _inventoryRepository;
    public InventoryService(IGenericRepository<InventoryItem, Guid> inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task<IEnumerable<InventoryItem>> GetAllInventoryItems()
    {
        var inventoryItems = await _inventoryRepository.GetAllAsync();
        return inventoryItems;
    }

    public async Task AddAsync(InventoryItem inventoryItem)
    {
        await _inventoryRepository.AddAsync(inventoryItem);
    }

    public async Task<InventoryItem> GetByIdAsync(Guid id)
    {
        return await _inventoryRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(InventoryItem inventoryItem)
    {
        await _inventoryRepository.UpdateAsync(inventoryItem);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _inventoryRepository.DeleteAsync(id);
    }
    
    public async Task<InventoryItem> RestockAsync(Guid id, int quantity)
    {
        var inventoryItem = await GetByIdAsync(id);
        if (inventoryItem == null)
            throw new Exception("Inventory item not found.");

        inventoryItem.Restock(quantity);
        await _inventoryRepository.UpdateAsync(inventoryItem);
        return inventoryItem;
    }

    public async Task<InventoryItem> DeductStockAsync(Guid id, int quantity)
    {
        var inventoryItem = await GetByIdAsync(id);
        if (inventoryItem == null)
            throw new Exception("Inventory item not found.");

        inventoryItem.DeductStock(quantity);
        await _inventoryRepository.UpdateAsync(inventoryItem);
        return inventoryItem;
    }
}