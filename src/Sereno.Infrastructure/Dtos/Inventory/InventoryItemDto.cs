using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Infrastructure.Dtos.Inventory;

public class InventoryItemDto
{
    public required string Name { get; set; }
    public int StockLevel { get; set; }
    public Guid SupplierId { get; set; }
    public ItemCategory Category { get; set; }
}