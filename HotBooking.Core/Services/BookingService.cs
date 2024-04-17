using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.BookingDtos;
using HotBooking.Core.Models.Enums;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class BookingService : IBookingService
{
    private readonly HotBookingDbContext dbContext;

    public BookingService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(BookingAddDto addDto)
    {
        bool doesUserExist = await dbContext.Users
            .AnyAsync(u => u.Id == addDto.UserId);

        if (doesUserExist == false) throw new InvalidModelDataException(UserErrors.NotFound);

        var room = await dbContext.Rooms
            .SingleOrDefaultAsync(r => r.PublicId == addDto.RoomId);

        if (room == null) throw new InvalidModelDataException(RoomErrors.NotFound);

        if (!room.Bookings.All(b => (addDto.CheckIn > b.CheckOut) || (addDto.CheckOut < b.CheckIn)))
        {
            throw new InvalidModelDataException(CartErrors.NoAvailableDates);
        }

        var booking = new Booking()
        {
            CheckIn = addDto.CheckIn,
            CheckOut = addDto.CheckOut,
            AdultsCount = addDto.AdultsCount,
            UserId = addDto.UserId,
            RoomId = room.Id,
            HotelId = room.HotelId
        };

        await dbContext.Bookings.AddAsync(booking);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<BookingListDto>> GetBookingsAsync(int userId)
    {
        var bookings = await dbContext.Bookings
            .Where(b => b.UserId == userId)
            .Select(b => new BookingListDto()
            {
                BookingPublicId = b.PublicId,
                RoomImageUrl = b.Room.RoomImages
                    .Select(i => i.Url).FirstOrDefault()!,
                CreatedOn = b.CreatedOn,
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
                AdultsCount = b.AdultsCount,
                RoomTitle = b.Room.Title,
                HotelName = b.Hotel.HotelName,
                HotelLocation = b.Hotel.CountryName + ", " + b.Hotel.StreetAddress
            })
            .ToArrayAsync();

        for (int i = 0; i < bookings.Count(); ++i)
        {
            if (bookings[i].CheckIn > DateTime.Now)
            {
                bookings[i].Status = BookingStatus.Upcoming;
                continue;
            }

            if (bookings[i].CheckOut < DateTime.Now)
            {
                bookings[i].Status = BookingStatus.Past;
                continue;
            }

            bookings[i].Status = BookingStatus.Current;
        }

        return bookings;
    }

    public async Task CancelAsync(Guid id)
    {
        var booking = await dbContext.Bookings
            .SingleOrDefaultAsync(b => b.PublicId == id);

        if (booking == null) throw new InvalidModelDataException(BookingErrors.NotFound);

        dbContext.Bookings.Remove(booking);
        await dbContext.SaveChangesAsync();
    }
}
