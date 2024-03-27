using HotBooking.Core.DTOs.FacilityDtos;

namespace HotBooking.Core.DTOs.HotelDtos;

public record BrowseHotelsOutputDto
(
    ICollection<PreviewHotelDto> SelectedHotels,
    ICollection<FacilityDto> Facilities,
    int TotalPages
);
