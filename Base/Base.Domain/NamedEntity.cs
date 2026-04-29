using System.ComponentModel.DataAnnotations;

namespace Base.Domain;

public abstract class NamedEntity : BaseEntity
{
    [MaxLength(128)]
    public string Name { get; set; } = default!;
}
