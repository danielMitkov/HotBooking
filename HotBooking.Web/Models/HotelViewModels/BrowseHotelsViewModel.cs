using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Web.Models.HotelViewModels;

public class BrowseHotelsViewModel
{
    public string? City { get; set; }

    public int Page { get; set; } = 1;

    public string CitiesJson { get; set; } = null!;

    public ICollection<PreviewHotelDto> Hotels { get; set; } = null!;

    public Pager<PreviewHotelDto> Pager { get; set; } = null!;
}
