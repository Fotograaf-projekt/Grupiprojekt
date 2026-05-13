using Base.Domain;

namespace App.Domain;

public class Album : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublic { get; set; } = true;

    public int PhotographerId { get; set; }
    public Photographer? Photographer { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}