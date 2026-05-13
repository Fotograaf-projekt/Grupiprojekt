using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Print : NamedEntity
{
    public int PrintId { get; set; }
    public Photographer? Photographer { get; set; }
    public string Email { get; set; } = string.Empty;
}