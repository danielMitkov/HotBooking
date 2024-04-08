using HotBooking.Core.DTOs.FacilityDtos;
using HotBooking.Core.DTOs.RoomDtos;

namespace HotBooking.Core.DTOs.HotelDtos;

public record HotelDetailsDto(
    string HotelName,
    string Description,
    string StreetAddress,
    string CityName,
    string CountryName,
    int StarRating,
    decimal AverageRating,
    int ReviewsCount,
    ICollection<FacilityPreviewDto> HotelsFacilities,
    //ICollection<RoomPreviewDto> Rooms,
    ICollection<string> ImagesUrls
);
