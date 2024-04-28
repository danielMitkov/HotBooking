using HotBooking.Core.Models.DTOs.UserDtos;

namespace HotBooking.Core.Interfaces;
public interface IUserService
{
    Task<ICollection<UserRoleDetailsDto>> AllUsersDetailsAsync();
    Task MakeAdminAsync(int userId);
    Task MakeNormalAsync(int userId);
    Task<UserDetailsDto?> GetDetailsAsync(int id);
    Task EditAsync(int id, UserDetailsDto detailsDto);
}
