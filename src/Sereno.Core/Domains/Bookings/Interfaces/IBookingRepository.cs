using Sereno.Core.Domains.Bookings.Entities;

namespace Sereno.Core.Domains.Bookings.Interfaces;

public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(Guid id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Guid id);
}