using HotBooking.Core.DTOs.HotelDtos;

namespace HotBooking.Core.Interfaces;

public interface IHotelsService : IErrorMessageProp
{
    Task<BrowseHotelsOutputDto?> GetFilteredHotelsAsync(BrowseHotelsInputDto inputDto);
    Task<ICollection<string>> GetMatchingCitiesAsync(string searchTerm);
}
