namespace HotBooking.Core.Models.DTOs.HotelDtos;

public record HotelPreviewDto(
Guid PublicId,
string ImageUrl,
string HotelName,
string Description,
string StreetAddress,
string CityName,
int StarRating,
decimal AverageRating,
int ReviewsCount
);
