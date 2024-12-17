using Sereno.Core.Domains.Payments.Entities;

namespace Sereno.Core.Domains.Payments.Interfaces;

public interface IPaymentRepository
{
    Task<Payment> GetByIdAsync(Guid id);
    Task<IEnumerable<Payment>> GetAllAsync();
    Task AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
    Task DeleteAsync(Guid id);
}