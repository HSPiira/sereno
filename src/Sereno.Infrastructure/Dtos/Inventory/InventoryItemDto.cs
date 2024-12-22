namespace Sereno.Infrastructure.Dtos;

public class InventoryItemDto
{
    public string Name { get; private set; }
    public int StockLevel { get; set; }
    public Guid SupplierId { get; private set; }
}