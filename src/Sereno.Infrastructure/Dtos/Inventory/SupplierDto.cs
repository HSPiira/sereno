namespace Sereno.Infrastructure.Dtos.Inventory;

public class SupplierDto
{
    public required string Name { get; set; }
    public string Address { get; set; } = string.Empty;
}