using SereniLux.Core.Common;
using SereniLux.Core.Domains.Inventory.ValueObjects;

namespace SereniLux.Core.Domains.Inventory.Entities;

public class InventoryItem : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public StockLevel StockLevel { get; set; }
    public ReorderLevel ReorderLevel { get; private set; }
    public Guid SupplierId { get; private set; }

    public InventoryItem(Guid itemId, string name, StockLevel stockLevel, ReorderLevel reorderLevel, Guid supplierId)
        : base(itemId)
    {
        Name = name;
        StockLevel = stockLevel;
        ReorderLevel = reorderLevel;
        SupplierId = supplierId;
    }

    public void Restock(int quantity) => StockLevel = StockLevel.Add(quantity);
    public void DeductStock(int quantity) => StockLevel = StockLevel.Subtract(quantity);
}