namespace HotBooking.Core.DTOs.RoomDtos;

public record RoomDetailsDto(
    Guid PublicId,
    string Title,
    string Description,
    int BedsCount,
    int SizeSquareMeters,
    decimal PricePerNight,
    IEnumerable<string> Features,
    IEnumerable<string> ImagesUrls
);
