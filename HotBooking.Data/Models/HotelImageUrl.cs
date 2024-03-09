using HotBooking.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;
public class HotelImageUrl
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(HotelImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;
}
