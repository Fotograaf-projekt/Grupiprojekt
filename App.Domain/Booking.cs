using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Booking : BaseEntity
{
    public DateTime Date { get; set; }

    [MaxLength(64)]
    public string Status { get; set; } = "Pending";

    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }

    public int ClientId {get;set; }
    public Client? Client { get; set; }

    public Availability? Availability { get; set; }
    public Invoice? Invoice {get; set; }
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    public ICollection<Review>? Reviews {get; set; }
}

