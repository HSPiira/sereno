using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Core.Domains.Inventory.Entities;

public class InventoryItem : BaseEntity
{
    public InventoryItem(string name, StockLevel stockLevel, ItemCategory category)
    {
        Name = name;
        StockLevel = stockLevel;
        Category = category;
    }

    public string Name { get; private set; }
    private StockLevel StockLevel { get; }
    public ItemCategory Category { get; private set; }

    public void Restock(int quantity)
    {
        StockLevel.AddStock(quantity);
    }

    public void DeductStock(int quantity)
    {
        StockLevel.DeductStock(quantity);
    }
}