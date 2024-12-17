namespace Sereno.Core.Domains.Inventory.ValueObjects;

public class StockLevel
{
    public StockLevel(int currentLevel, int reorderLevel)
    {
        if (currentLevel < 0)
            throw new ArgumentException("Current stock level cannot be negative.");
        if (reorderLevel < 0)
            throw new ArgumentException("Reorder level cannot be negative.");

        CurrentLevel = currentLevel;
        ReorderLevel = reorderLevel;
    }

    private int CurrentLevel { get; set; }
    public int ReorderLevel { get; private set; }

    public void AddStock(int quantity)
    {
        CurrentLevel += quantity;
    }

    public void DeductStock(int quantity)
    {
        if (quantity > CurrentLevel)
            throw new InvalidOperationException("Insufficient stock.");
        CurrentLevel -= quantity;
    }
}