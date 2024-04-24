namespace HotBooking.Core.Models.DTOs.ManagerDtos;

public record ManagerHotelPreviewDto(
Guid PublicId,
string Name,
string StreetAddress,
string CityName,
string CountryName,
int StarRating
);
