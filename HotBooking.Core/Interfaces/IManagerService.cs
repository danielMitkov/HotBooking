using HotBooking.Core.Models.DTOs.ManagerDtos;

namespace HotBooking.Core.Interfaces;

public interface IManagerService
{
    Task<bool> DoesManagerExistAsync(int userId);
    Task BecomeAsync(int userId, ManagerFormDto formDto);
    Task<ICollection<ManagerHotelPreviewDto>> MyHotelsAsync(int userId);
    Task<ICollection<ManagerRoomPreviewDto>> MyRoomsAsync(int userId, Guid hotelId);
}
