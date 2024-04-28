namespace HotBooking.Core.Models.DTOs.UserDtos;

public class UserRoleDetailsDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public bool isAdmin { get; set; }
}

