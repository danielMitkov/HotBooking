using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotBooking.Data.Constants;

namespace HotBooking.Data.Models;

public class Room : BaseEntity
{
    public Room()
    {
        Features = new HashSet<Feature>();
        RoomImages = new HashSet<RoomImageUrl>();
    }

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

    public Booking? Booking { get; set; }

    public ICollection<Feature> Features { get; set; }

    public ICollection<RoomImageUrl> RoomImages { get; set; }
}
