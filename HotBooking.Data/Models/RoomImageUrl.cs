using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class RoomImageUrl : BaseEntity
{
    [Required]
    [MaxLength(RoomImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;
}
