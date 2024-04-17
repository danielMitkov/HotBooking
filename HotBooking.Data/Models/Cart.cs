using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
