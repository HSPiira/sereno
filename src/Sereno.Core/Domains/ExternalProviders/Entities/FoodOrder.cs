using Sereno.Core.Common;
using Sereno.Core.Domains.ExternalProviders.ValueObjects;

namespace Sereno.Core.Domains.ExternalProviders.Entities;

public class FoodOrder : BaseEntity
{
    public FoodOrder(Guid providerId, List<MenuItem> orderedItems)
    {
        ProviderId = providerId;
        OrderedItems = orderedItems ?? new List<MenuItem>();
        Status = OrderStatus.Pending;
    }

    public Guid ProviderId { get; private set; }
    public List<MenuItem> OrderedItems { get; private set; }
    public OrderStatus Status { get; private set; }

    public void MarkAsDelivered()
    {
        Status = OrderStatus.Delivered;
    }
}