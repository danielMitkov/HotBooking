using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public interface IActive
{
    public Guid PublicId { get; set; }
}

public abstract class BaseEntity : IActive
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
}
