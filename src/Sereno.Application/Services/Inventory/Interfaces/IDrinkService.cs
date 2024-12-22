using Sereno.Core.Domains.Inventory.Entities;

namespace Sereno.Application.Services.Inventory.Interfaces;

public interface IDrinkService
{
    Task<IEnumerable<Drink>> Drinks();
    Task AddAsync(Drink drink);
    Task<Drink> GetByIdAsync(Guid id);
    Task UpdateAsync(Drink drink);
    Task DeleteAsync(Guid id);
}