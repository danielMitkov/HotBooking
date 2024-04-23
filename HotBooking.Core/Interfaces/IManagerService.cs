namespace HotBooking.Core.Interfaces;

public interface IManagerService
{
    Task<bool> DoesManagerExistAsync(int userId);
}
