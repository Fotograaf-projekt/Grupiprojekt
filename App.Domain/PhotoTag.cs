using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class PhotoTag : BaseEntity
{
    public int PhotoId { get; set; }
    public int PhotoTagId { get; set; }
}