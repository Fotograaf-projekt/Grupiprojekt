using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Invoice : BaseEntity
{
    public DateTime IssuedDate { get; set; }

    public decimal Amount { get; set; }

    [MaxLength(64)]
    public string Status { get; set; } = "Unpaid";

    public int BookingId { get; set; }
    public Booking? Booking { get; set; }
}
