using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class SocialLink : BaseEntity
{
    [MaxLength(64)]
    public string Platform { get; set; } = default!;

    [MaxLength(512)]
    [Url]
    public string Url { get; set; } = default!;

    public int PhotographerId { get; set; }
    public Photographer? Photographer { get; set; }
}
