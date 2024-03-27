using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;
}
