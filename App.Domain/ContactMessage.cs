using Base.Domain;
namespace App.Domain;

public class ContactMessage : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Text { get; set; } = default!;

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int ServiceId { get; set; }
    public Service? Service { get; set; }
}
