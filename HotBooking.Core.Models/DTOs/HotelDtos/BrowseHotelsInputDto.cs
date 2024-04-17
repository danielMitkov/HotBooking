using HotBooking.Core.Models.Enums;

namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record BrowseHotelsInputDto(
int CurrentPage,
int PageSize,
string City,
DateTime CheckInDate,
DateTime CheckOutDate,
int AdultsCount,
int RoomsCount,
HotelSorting Sorting,
IEnumerable<Guid> FacilitySelectedPublicIds
);
