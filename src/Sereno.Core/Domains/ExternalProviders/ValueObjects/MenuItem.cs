namespace Sereno.Core.Domains.ExternalProviders.ValueObjects;

public class MenuItem
{
    public MenuItem(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Menu item name cannot be empty.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }
}