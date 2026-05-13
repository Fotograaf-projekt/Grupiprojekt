using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Tag : BaseEntity
{
    [MaxLength(64)]
    public string Name { get; set; } = default!;

    public int TagId { get; set; }

    // [MaxLength(512)]
    // [Url]
    // public string Url { get; set; } = default!;
}
