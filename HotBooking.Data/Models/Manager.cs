using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class Manager
{
    public Manager()
    {
        Hotels = new HashSet<Hotel>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ManagerConstants.PhoneNumberLengthMax)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<Hotel> Hotels { get; set; }
}
