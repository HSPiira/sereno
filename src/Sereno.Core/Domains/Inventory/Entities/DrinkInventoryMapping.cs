using Sereno.Core.Common;

namespace Sereno.Core.Domains.Inventory.Entities;

public class DrinkInventoryMapping : BaseEntity
{
    public DrinkInventoryMapping(){}
    public int DrinkId { get; private set; }
    public int InventoryItemId { get; private set; }
    public int QuantityPerUnit { get; private set; }

    public DrinkInventoryMapping(Guid mappingId, int drinkId, int inventoryItemId, int quantityPerUnit)
    {
        DrinkId = drinkId;
        InventoryItemId = inventoryItemId;
        QuantityPerUnit = quantityPerUnit;
    }
}