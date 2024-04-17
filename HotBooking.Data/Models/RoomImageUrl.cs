using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class RoomImageUrl : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(RoomImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;
}
