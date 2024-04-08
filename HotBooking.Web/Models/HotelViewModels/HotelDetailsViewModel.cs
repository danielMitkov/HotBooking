using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Web.Models.HotelViewModels;

public class HotelDetailsViewModel
{
    public SearchHotelsViewModel Search { get; set; } = null!;

    public HotelDetailsDto Hotel { get; set; } = null!;
}
