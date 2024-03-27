using HotBooking.Core.Enums;

namespace HotBooking.Core.DTOs.HotelDtos;

public record BrowseHotelsInputDto
(
    int CurrentPage,
    int PageSize,
    string City,
    HotelSorting Sorting,
    ICollection<Guid> FacilitySelectedPublicIds
);
