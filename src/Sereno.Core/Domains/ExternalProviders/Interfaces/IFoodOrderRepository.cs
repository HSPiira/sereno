using Sereno.Core.Domains.ExternalProviders.Entities;

namespace Sereno.Core.Domains.ExternalProviders.Interfaces;

public interface IFoodOrderRepository
{
    Task<FoodOrder> GetByIdAsync(Guid id);
    Task<IEnumerable<FoodOrder>> GetAllAsync();
    Task AddAsync(FoodOrder foodOrder);
    Task UpdateAsync(FoodOrder foodOrder);
    Task DeleteAsync(Guid id);
}