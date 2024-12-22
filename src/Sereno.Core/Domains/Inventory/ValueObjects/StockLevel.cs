namespace Sereno.Core.Domains.Inventory.ValueObjects;

public record StockLevel
{
    public int Amount { get; private set; }

    public StockLevel(int amount)
    {
        Amount = amount;
    }
    public StockLevel Add(int amount)
    { 
        if (amount < 0) throw new ArgumentException("StockLevel cannot be negative.");
        return this with { Amount = Amount + amount };
    }
    public StockLevel Subtract(int amount)
    {
        if (Amount < amount) throw new InvalidOperationException("Insufficient quantity.");
        return this with { Amount = Amount - amount };
    }
}