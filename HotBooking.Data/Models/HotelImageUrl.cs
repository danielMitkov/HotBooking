using HotBooking.Data.Constants;
using HotBooking.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBooking.Data.Models;

public class HotelImageUrl : IPublicId
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(HotelImageUrlConstants.UrlLengthMax)]
    public string Url { get; set; } = null!;

    [Required]
    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;
}
