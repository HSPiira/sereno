namespace Sereno.Core.Domains.Booking.ValueObjects;

public class TimeSlot
{
    public TimeSlot(DateTime startTime, DateTime endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.");

        StartTime = startTime;
        EndTime = endTime;
    }

    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
}