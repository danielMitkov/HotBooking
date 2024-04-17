using HotBooking.Core.Models.DTOs.UserDtos;

namespace HotBooking.Core.Interfaces;
public interface IUserService
{
    Task<UserDetailsDto?> GetDetailsAsync(int id);
    Task EditAsync(int id, UserDetailsDto detailsDto);
}
