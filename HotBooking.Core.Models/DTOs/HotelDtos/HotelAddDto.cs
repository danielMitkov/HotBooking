namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record HotelAddDto(
string HotelName,
string Description,
string StreetAddress,
string CityName,
string CountryName,
int StarRating,
IEnumerable<Guid> SelectedFacilityIds,
string ImageUrls
);
