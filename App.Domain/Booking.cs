using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Booking : BaseEntity
{
    public DateTime Date { get; set; }

    [MaxLength(64)]
    public string Status { get; set; } = default!;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
}

