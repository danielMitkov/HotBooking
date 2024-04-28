namespace HotBooking.Core.Models.DTOs.RoomDtos;

public record RoomEditDto(
Guid PublicId,
string Title,
string Description,
int BedsCount,
int RoomSizeSquareMeters,
decimal PricePerNight,
IEnumerable<Guid> SelectedFeatureIds,
string ImageUrls);
