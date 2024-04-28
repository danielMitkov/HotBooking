namespace HotBooking.Core.Models.DTOs.ManagerDtos;

public record ManagerRoomPreviewDto(
Guid PublicId,
string Title,
int BedsCount,
decimal PricePerNight);
