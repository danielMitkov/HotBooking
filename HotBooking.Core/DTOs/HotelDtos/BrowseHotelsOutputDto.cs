using HotBooking.Core.DTOs.FacilityDtos;

namespace HotBooking.Core.DTOs.HotelDtos;

public record BrowseHotelsOutputDto(
    IEnumerable<PreviewHotelDto> SelectedHotels,
    IEnumerable<FacilityDto> Facilities,
    int TotalPages,
    int AllHotelsCount
);
