using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Tag : NamedEntity
{
    public int TagId { get; set; }
    public Photographer? Photographer { get; set; }

    // [MaxLength(512)]
    // [Url]
    // public string Url { get; set; } = default!;
}
