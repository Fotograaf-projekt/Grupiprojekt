using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Photographer : NamedEntity
{
    [MaxLength(256)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [MaxLength(2000)]
    public string? About { get; set; }

    [MaxLength(512)]
    public string? ProfileImageUrl { get; set; }

    public ICollection<SocialLink>? SocialLinks { get; set; }
    public ICollection<Service>? Services { get; set; }
}
