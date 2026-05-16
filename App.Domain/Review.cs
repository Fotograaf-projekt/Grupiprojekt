using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Review : BaseEntity
{
    [MaxLength(128)]
    public string Author { get; set; } = default!;

    public int Rating { get; set; }

    [MaxLength(2000)]
    public string? Text { get; set; }

    public int BookingId { get; set; }
    public Booking? Booking { get; set; }
}
