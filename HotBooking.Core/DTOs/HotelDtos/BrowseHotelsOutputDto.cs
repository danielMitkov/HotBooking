using HotBooking.Core.DTOs.FacilityDtos;

namespace HotBooking.Core.DTOs.HotelDtos;

public record BrowseHotelsOutputDto(
IEnumerable<HotelPreviewDto> SelectedHotels,
IEnumerable<FacilityChecksDto> Facilities,
int TotalPages,
int AllHotelsCount
);
