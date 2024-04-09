namespace HotBooking.Core.DTOs.RoomDtos;

public record RoomPreviewDto(
    Guid PublicId,
    string Title,
    //desc
    int BedsCount,
    int SizeSquareMeters,
    decimal PricePerNight
);
