using Sereno.Core.Domains.Inventory.ValueObjects;

namespace Sereno.Infrastructure.Dtos.Records;

public record ConcreteStockLevel(int Amount) : StockLevel(Amount);