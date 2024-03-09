using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;
public class RoomImageUrl
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(RoomImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;
}
