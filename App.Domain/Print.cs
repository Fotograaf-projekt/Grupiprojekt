using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Print : BaseEntity
{
    public int PrintId { get; set; }
    public Photographer? Photographer { get; set; }
    //mmmmmmmm huh?
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}