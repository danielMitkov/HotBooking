using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotBooking.Data.Constants;

namespace HotBooking.Data.Models;

public class Room : BaseEntity
{
    [Required]
    [MaxLength(RoomConstants.TitleLengthMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(RoomConstants.DescriptionLengthMax)]
    public string Description { get; set; } = null!;

    [Required]
    public int BedsCount { get; set; }

    [Required]
    public int RoomSizeSquareMeters { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerNight { get; set; }

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public ICollection<RoomFeature> RoomsFeatures { get; set; } = new HashSet<RoomFeature>();

    public ICollection<RoomImageUrl> RoomImages { get; set; } = new HashSet<RoomImageUrl>();
}
