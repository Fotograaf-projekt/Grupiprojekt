using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Service : NamedEntity
{
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public int PhotographerId { get; set; }
    public Photographer? Photographer { get; set; }
}
