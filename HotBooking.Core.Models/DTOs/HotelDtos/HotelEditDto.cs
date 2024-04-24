namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record HotelEditDto(
Guid PublicId,
string HotelName,
string Description,
string StreetAddress,
string CityName,
string CountryName,
int StarRating,
IEnumerable<Guid> SelectedFacilityIds,
string ImageUrls
);
