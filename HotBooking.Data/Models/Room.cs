using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotBooking.Data.Constants;

namespace HotBooking.Data.Models;
public class Room
{
    public Room()
    {
        Features = new HashSet<Feature>();
        RoomImages = new HashSet<ImageUrl>();
        Reviews = new HashSet<Review>();

        IsAvailable = true;
    }

    [Key]
    public int Id { get; set; }

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
    public decimal PricePerNight { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    public Booking? Booking { get; set; }

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    public ICollection<Feature> Features { get; set; }

    public ICollection<ImageUrl> RoomImages { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
