using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.CartDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class CartService : ICartService
{
    private readonly HotBookingDbContext dbContext;

    public CartService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(CartAddDto addDto)
    {
        if ((await DoesUserHaveCart(addDto.UserId)) == false)
        {
            var newCart = new Cart()
            {
                UserId = addDto.UserId
            };

            await dbContext.Carts.AddAsync(newCart);
            await dbContext.SaveChangesAsync();
        }

        int? roomId = await dbContext.Rooms
            .Where(r => r.PublicId == addDto.RoomId)
            .Select(r => r.Id)
            .SingleOrDefaultAsync();

        if (roomId == null)
        {
            throw new InvalidModelDataException(RoomErrors.NotFound);
        }

        var booking = new Booking()
        {
            CheckIn = addDto.CheckIn,
            CheckOut = addDto.CheckOut,
            AdultsCount = addDto.AdultsCount,
            UserId = addDto.UserId,
            RoomId = (int)roomId
        };

        var cart = await dbContext.Carts
            .SingleOrDefaultAsync(c => c.UserId == addDto.UserId);

        if (cart == null)
        {
            throw new InvalidModelDataException(CartErrors.NotFound);
        }

        cart.Bookings.Add(booking);

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DoesUserHaveCart(int userId)
    {
        var hasCart = await dbContext.Carts
            .AnyAsync(c => c.UserId == userId);

        return hasCart;
    }
}
