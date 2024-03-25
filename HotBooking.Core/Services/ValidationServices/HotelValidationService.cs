using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Data.Common;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services.ValidationServices;
public class HotelValidationService: IHotelValidationService
{
    private readonly IRepository repository;

    public HotelValidationService(IRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> IsCityFoundAsync(string city)
    {
        bool isCityFound = await repository
            .AllReadOnly<Hotel>()
            .AnyAsync(h => h.CityName == city);

        return isCityFound;
    }
}
