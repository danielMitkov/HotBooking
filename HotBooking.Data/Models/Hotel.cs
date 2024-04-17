using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class Hotel : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(HotelConstants.HotelNameLengthMax)]
    public string HotelName { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.DescriptionLengthMax)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.StreetAddressLengthMax)]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.CityNameLengthMax)]
    public string CityName { get; set; } = null!;

    [Required]
    [MaxLength(HotelConstants.CountryNameLengthMax)]
    public string CountryName { get; set; } = null!;

    [Required]
    public int StarRating { get; set; }

    public ICollection<HotelFacility> HotelsFacilities { get; set; } = new HashSet<HotelFacility>();

    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

    public ICollection<HotelImageUrl> HotelImages { get; set; } = new HashSet<HotelImageUrl>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
