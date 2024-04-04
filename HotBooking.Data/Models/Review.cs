using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class Review : BaseEntity
{
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal RatingScore { get; set; }

    [Required]
    [MaxLength(ReviewConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ReviewConstants.CommentMax)]
    public string Comment { get; set; } = null!;

    [Required]
    public DateTime ReviewedOn { get; set; }

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    [Required]
    public int BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public Booking Booking { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
