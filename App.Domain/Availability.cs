using Base.Domain;

namespace App.Domain;

public class Availability : BaseEntity
{
    public DateTime Date { get; set; }
    public string StartTime { get; set; } = default!;
    public string EndTime { get; set; } = default!;
    public bool IsFree { get; set; } = true;

    public int? BookingId { get; set; }
    public Booking? Booking { get; set; }
}
