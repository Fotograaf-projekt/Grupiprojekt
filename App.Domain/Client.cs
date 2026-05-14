using Base.Domain;

namespace App.Domain;

public class Client : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ICollection<ContactMessage>? ContactMessages { get; set; }
    public ICollection<Booking>? Bookings { get; set; }

}
