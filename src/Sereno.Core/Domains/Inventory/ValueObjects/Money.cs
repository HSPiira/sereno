namespace Sereno.Core.Domains.Inventory.ValueObjects;

public record Money
{
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    public string Currency { get; set; }
    public decimal Amount { get; set; }
    
    public Money Add(decimal amount) => this with { Amount = Amount + amount };
    public Money Subtract(decimal amount)
    {
        if (Amount < amount) throw new InvalidOperationException("Insufficient funds.");
        return this with { Amount = Amount - amount };
    }
}
