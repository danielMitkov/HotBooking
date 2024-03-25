using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        PublicId = Guid.NewGuid();
        IsActive = true;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; }
}
