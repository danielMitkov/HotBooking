namespace HotBooking.Core.DTOs.HotelDtos;

public record PreviewHotelDto(
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
