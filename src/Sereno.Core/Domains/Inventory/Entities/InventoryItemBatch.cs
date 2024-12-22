using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Core.Domains.Inventory.Entities;

public class InventoryItemBatch : BaseEntity
{
    public int ItemId { get; private set; }
    public int SupplierId { get; private set; }
    private StockLevel StockLevel { get; set; }
    public DateTime ReceivedDate { get; private set; }

    public InventoryItemBatch(Guid batchId, int itemId, int supplierId, StockLevel stockLevel, DateTime receivedDate)
    {
        ItemId = itemId;
        SupplierId = supplierId;
        StockLevel = stockLevel;
        ReceivedDate = receivedDate;
    }

    public void DeductQuantity(int amount) => StockLevel = StockLevel.Subtract(amount);
}