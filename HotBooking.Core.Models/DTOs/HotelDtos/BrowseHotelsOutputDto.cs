using HotBooking.Core.Models.DTOs.FacilityDtos;

namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record BrowseHotelsOutputDto(
IEnumerable<HotelPreviewDto> SelectedHotels,
IEnumerable<FacilityChecksDto> Facilities,
int TotalPages,
int AllHotelsCount
);
