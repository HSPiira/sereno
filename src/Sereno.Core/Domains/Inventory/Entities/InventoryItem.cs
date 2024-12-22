using System.ComponentModel.DataAnnotations;
using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Core.Domains.Inventory.Entities;

public class InventoryItem : BaseEntity
{
    public InventoryItem(){}
    [Required]
    public string Name { get; set; }
    public StockLevel StockLevel { get; set; }
    public Guid SupplierId { get; init; }
    public ItemCategory Category { get; set; }

    public InventoryItem(Guid id, string name, StockLevel stockLevel, Guid supplierId, ItemCategory category)
    {
        Id = id;
        Name = name;
        StockLevel = stockLevel;
        SupplierId = supplierId;
        Category = category;
    }

    public void Restock(int quantity) => StockLevel = StockLevel.Add(quantity);
    public void DeductStock(int quantity) => StockLevel = StockLevel.Subtract(quantity);
}