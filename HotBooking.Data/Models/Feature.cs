using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class Feature
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string IconClassName { get; set; } = null!;
}
