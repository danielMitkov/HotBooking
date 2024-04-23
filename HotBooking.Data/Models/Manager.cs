using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Manager : IPublicId
{
    public Manager()
    {
        PublicId = Guid.NewGuid();
        IsActive = true;

        Hotels = new HashSet<Hotel>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string Department { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [Required]
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<Hotel> Hotels { get; set; }
}
