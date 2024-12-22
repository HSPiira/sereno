using Sereno.Core.Common;
using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Core.Domains.Inventory.Entities;

public class Drink : BaseEntity
{
    public Drink(){}
    public string Name { get; private set; }
    public string Category { get; private set; }
    public Money Price { get; private set; }
    public int StockQuantity { get; private set; }

    public Drink(Guid drinkId, string name, string category, Money price, int stockQuantity)
    {
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void UpdateStock(int newQuantity) => StockQuantity = newQuantity;
}