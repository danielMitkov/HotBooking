using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
