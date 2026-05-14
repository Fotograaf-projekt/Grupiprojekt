using Base.Domain;

namespace App.Domain;

public class Photo : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime TakenAt { get; set; }
    public bool IsPublic { get; set; } = true;

    public int AlbumId { get; set; }
    public Album? Album { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    //public ICollection<PhotoTag>? PhotoTags { get; set; }
    //reesi, kui phototagi teed, saad mu rea tagasi panna siia, praegu olen valja
    //kommenteerinud sest muidu compile error
}