using HotBooking.Core.Models.DTOs.FacilityDtos;
using HotBooking.Core.Models.DTOs.RoomDtos;

namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record HotelDetailsDtoOutput(
string Name,
string Description,
string StreetAddress,
string CityName,
string CountryName,
int StarRating,
decimal AverageRating,
int ReviewsCount,
IEnumerable<FacilityDetailsDto> Facilities,
IEnumerable<string> ImagesUrls,
IEnumerable<RoomDetailsDto> Rooms
);
