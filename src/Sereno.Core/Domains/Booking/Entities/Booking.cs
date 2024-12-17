using Sereno.Core.Common;
using Sereno.Core.Domains.Booking.ValueObjects;

namespace Sereno.Core.Domains.Booking.Entities;

public class Booking : BaseEntity
{
    public Booking(Guid customerId, DateTime eventDate, TimeSlot timeSlot)
    {
        CustomerId = customerId;
        EventDate = eventDate;
        TimeSlot = timeSlot;
        Status = BookingStatus.Pending;
    }

    public Guid CustomerId { get; private set; }
    public DateTime EventDate { get; private set; }
    public TimeSlot TimeSlot { get; private set; }
    public BookingStatus Status { get; private set; }

    public void Confirm()
    {
        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }
}