using Base.Domain;

namespace App.Domain;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Album>? Albums { get; set; }
    public ICollection<Photo>? Photos { get; set; }
}