using HotBooking.Core.Models.DTOs.HotelDtos;

namespace HotBooking.Web.Models.HotelViewModels;

public class HotelDetailsViewModel
{
    public Guid HotelId { get; set; }

    public SearchHotelsViewModel Search { get; set; } = null!;

    public HotelDetailsDtoOutput Hotel { get; set; } = null!;
}
