using HotBooking.Core.Enums;

namespace HotBooking.Core.DTOs.HotelDtos;

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
