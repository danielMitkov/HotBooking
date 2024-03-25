namespace HotBooking.Core.Interfaces.ValidationInterfaces;
public interface IHotelValidationService
{
    Task<bool> IsCityFoundAsync(string city);
}
