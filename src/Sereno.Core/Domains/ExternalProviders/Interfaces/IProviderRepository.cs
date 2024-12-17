using Sereno.Core.Domains.ExternalProviders.Entities;

namespace Sereno.Core.Domains.ExternalProviders.Interfaces;

public interface IProviderRepository
{
    Task<Provider> GetByIdAsync(Guid id);
    Task<IEnumerable<Provider>> GetAllAsync();
    Task AddAsync(Provider provider);
    Task UpdateAsync(Provider provider);
    Task DeleteAsync(Guid id);
}