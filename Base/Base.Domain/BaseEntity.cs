namespace Base.Domain;

public abstract class BaseEntity : BaseEntity<int>
{
}

public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}
