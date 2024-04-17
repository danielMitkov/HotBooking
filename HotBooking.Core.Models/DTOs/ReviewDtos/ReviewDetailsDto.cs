namespace HotBooking.Core.Models.DTOs.ReviewDtos;

public record ReviewDetailsDto(
bool IsMyReview,
Guid PublicId,
decimal Score,
string Title,
string Comment,
DateTime ReviewedOnDate,
DateTime CheckInDate,
DateTime CheckOutDate,
int AdultsCount,
string RoomTitle
);
