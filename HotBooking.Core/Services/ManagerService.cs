using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.ManagerDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class ManagerService : IManagerService
{
    private readonly HotBookingDbContext dbContext;

    public ManagerService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DoesManagerExistAsync(int userId)
    {
        bool isManagerFound = await dbContext.Managers
            .AnyAsync(m => m.UserId == userId);

        return isManagerFound;
    }

    public async Task BecomeAsync(int userId, ManagerFormDto formDto)
    {
        bool isUserFound = await dbContext.Users
            .AnyAsync(u => u.Id == userId);

        if (isUserFound == false)
        {
            throw new InvalidModelDataException(UserErrors.NotFound);
        }

        bool isAlreadyManager = await dbContext.Managers
            .AnyAsync(m => m.UserId == userId);

        if (isAlreadyManager == true)
        {
            throw new InvalidModelDataException(ManagerErrors.AlreadyManager);
        }

        bool doesManagerPhoneNumberAlreadyExist = await dbContext.Managers
            .AnyAsync(m => m.PhoneNumber == formDto.PhoneNumber);

        if (doesManagerPhoneNumberAlreadyExist == true)
        {
            throw new InvalidModelDataException(ManagerErrors.PhoneNumberAlreadyExists);
        }

        var manager = new Manager()
        {
            CompanyName = formDto.CompanyName,
            Department = formDto.Department,
            PhoneNumber = formDto.PhoneNumber,
            UserId = userId
        };

        await dbContext.Managers.AddAsync(manager);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<ManagerHotelPreviewDto>> MyHotelsAsync(int userId)
    {
        bool doesManagerExist = await dbContext.Managers
            .AnyAsync(m => m.UserId == userId);

        if (doesManagerExist == false)
        {
            throw new InvalidModelDataException(ManagerErrors.NotFound);
        }

        var hotelDtos = await dbContext.Hotels
            .Where(h => h.IsActive)
            .Where(h => h.Manager.UserId == userId)
            .Select(h => new ManagerHotelPreviewDto(
                h.PublicId,
                h.HotelName,
                h.StreetAddress,
                h.CityName,
                h.CountryName,
                h.StarRating))
            .ToListAsync();

        return hotelDtos;
    }

    public async Task<ICollection<ManagerRoomPreviewDto>> MyRoomsAsync(int userId, Guid hotelId)
    {
        bool doesManagerExist = await dbContext.Managers.AnyAsync(m => m.UserId == userId);

        if (doesManagerExist == false) throw new InvalidModelDataException(ManagerErrors.NotFound);

        var hotel = await dbContext.Hotels.Include(h => h.Manager).SingleOrDefaultAsync(h => h.PublicId == hotelId);

        if (hotel == null) throw new InvalidModelDataException(HotelErrors.NotFound);

        if (hotel.Manager.UserId != userId) throw new InvalidModelDataException(ManagerErrors.NotTheHotelManager);

        var roomDtos = await dbContext.Rooms.Where(r => r.IsActive).Where(r => r.Hotel.PublicId == hotelId)
            .Select(r => new ManagerRoomPreviewDto(
                r.PublicId,
                r.Title,
                r.BedsCount,
                r.PricePerNight))
            .ToListAsync();

        return roomDtos;
    }
}
