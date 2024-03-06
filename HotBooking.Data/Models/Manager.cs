using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class Manager
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ManagerConstants.PhoneNumberLengthMax)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public Hotel? Hotel { get; set; } = null!;
}
