using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.RoomDtos;

namespace HotBooking.Core.DTOs.HotelDtos;

public record HotelDetailsDtoOutput(
    string Name,
    string Description,
    string StreetAddress,
    string CityName,
    string CountryName,
    int StarRating,
    decimal AverageRating,
    int ReviewsCount,
    IEnumerable<FacilityPreviewDto> Facilities,
    IEnumerable<string> ImagesUrls,
    IEnumerable<RoomPreviewDto> Rooms
);
