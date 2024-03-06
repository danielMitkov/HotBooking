using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RatingScore { get; set; }

    [Required]
    [MaxLength(ReviewConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ReviewConstants.CommentMax)]
    public string Comment { get; set; } = null!;

    [Required]
    public DateTime ReviewedOn { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;

    [Required]
    public int BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public Booking Booking { get; set; } = null!;
}
