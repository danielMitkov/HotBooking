using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Manager : BaseEntity
{
    public Manager()
    {
        Hotels = new HashSet<Hotel>();
    }

    [Required]
    [MaxLength(ManagerConstants.PhoneNumberLengthMax)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<Hotel> Hotels { get; set; }
}
