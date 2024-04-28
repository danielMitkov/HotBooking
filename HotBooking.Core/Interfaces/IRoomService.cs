using HotBooking.Core.Models.DTOs.RoomDtos;

namespace HotBooking.Core.Interfaces;

public interface IRoomService
{
    Task AddAsync(int userId, Guid hotelPublicId, RoomAddDto addDto);
    Task<RoomEditDto> GetForEditAsync(int userId, Guid roomId);
    Task<Guid> EditAsync(int userId, RoomEditDto editDto);
    Task<Guid> DeleteAsync(int userId, Guid roomId);
}
