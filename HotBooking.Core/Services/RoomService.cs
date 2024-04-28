using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.RoomDtos;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class RoomService : IRoomService
{
    private readonly HotBookingDbContext dbContext;

    public RoomService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(int userId, Guid hotelPublicId, RoomAddDto addDto)
    {
        var manager = await dbContext.Managers
            .FirstOrDefaultAsync(m => m.UserId == userId);

        if (manager == null)
        {
            throw new InvalidModelDataException(ManagerErrors.NotFound);
        }

        int hotelId = await dbContext.Hotels
            .Where(h => h.IsActive)
            .Where(h => h.PublicId == hotelPublicId)
            .Select(h => h.Id)
            .SingleOrDefaultAsync();

        if (hotelId == 0)
        {
            throw new InvalidModelDataException(HotelErrors.NotFound);
        }

        var room = new Room()
        {
            Title = addDto.Title,
            Description = addDto.Description,
            BedsCount = addDto.BedsCount,
            RoomSizeSquareMeters = addDto.RoomSizeSquareMeters,
            PricePerNight = addDto.PricePerNight,
            HotelId = hotelId
        };

        await dbContext.Rooms.AddAsync(room);
        await dbContext.SaveChangesAsync();

        string[] urls = addDto.ImageUrls
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var url in urls)
        {
            var roomImageUrl = new RoomImageUrl()
            {
                Url = url,
                Room = room
            };

            dbContext.RoomImageUrls.Add(roomImageUrl);
        }

        await dbContext.SaveChangesAsync();


        var selectedFeaturesEntities = await dbContext.Features
            .Where(f => addDto.SelectedFeatureIds.Contains(f.PublicId))
            .ToListAsync();

        foreach (var feature in selectedFeaturesEntities)
        {
            var roomFeature = new RoomFeature()
            {
                Feature = feature,
                Room = room
            };

            dbContext.RoomsFeatures.Add(roomFeature);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<RoomEditDto> GetForEditAsync(int userId, Guid roomId)
    {
        bool isUserTheHotelManager = await dbContext.Rooms
            .AnyAsync(r => r.PublicId == roomId && r.Hotel.Manager.UserId == userId);

        if (isUserTheHotelManager == false)
        {
            throw new InvalidModelDataException(ManagerErrors.NotTheHotelManager);
        }

        var room = await dbContext.Rooms
            .FirstOrDefaultAsync(r => r.PublicId == roomId);

        if (room == null)
        {
            throw new InvalidModelDataException(RoomErrors.NotFound);
        }

        var selectedFeatureIds = await dbContext.RoomsFeatures
            .Where(rf => rf.RoomId == room.Id)
            .Select(rf => rf.Feature.PublicId)
            .ToListAsync();

        var imageUrls = await dbContext.RoomImageUrls
            .Where(i => i.RoomId == room.Id)
            .Select(i => i.Url)
            .ToArrayAsync();

        var editDto = new RoomEditDto(
            roomId,
            room.Title,
            room.Description,
            room.BedsCount,
            room.RoomSizeSquareMeters,
            room.PricePerNight,
            selectedFeatureIds,
            string.Join(Environment.NewLine, imageUrls));

        return editDto;
    }

    public async Task<Guid> EditAsync(int userId, RoomEditDto editDto)
    {
        var room = await dbContext.Rooms
            .Include(r => r.Hotel)
            .FirstOrDefaultAsync(r => r.PublicId == editDto.PublicId);

        if (room == null)
        {
            throw new InvalidModelDataException(RoomErrors.NotFound);
        }

        bool isUserTheHotelManager = await dbContext.Hotels
            .AnyAsync(h => h.Id == room.HotelId && h.Manager.UserId == userId);

        if (isUserTheHotelManager == false)
        {
            throw new InvalidModelDataException(ManagerErrors.NotTheHotelManager);
        }

        room.Title = editDto.Title;
        room.Description = editDto.Description;
        room.BedsCount = editDto.BedsCount;
        room.RoomSizeSquareMeters = editDto.RoomSizeSquareMeters;
        room.PricePerNight = editDto.PricePerNight;

        var roomImages = await dbContext.RoomImageUrls
            .Where(i => i.RoomId == room.Id)
            .ToListAsync();

        dbContext.RoomImageUrls.RemoveRange(roomImages);

        string[] urls = editDto.ImageUrls
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var url in urls)
        {
            var roomImageUrl = new RoomImageUrl()
            {
                Url = url,
                RoomId = room.Id
            };

            dbContext.RoomImageUrls.Add(roomImageUrl);
        }

        await dbContext.SaveChangesAsync();

        var roomFeatures = await dbContext.RoomsFeatures
            .Where(hf => hf.RoomId == room.Id)
            .ToListAsync();

        dbContext.RoomsFeatures.RemoveRange(roomFeatures);

        var selectedFeaturesEntities = await dbContext.Features
            .Where(f => editDto.SelectedFeatureIds.Contains(f.PublicId))
            .ToListAsync();

        foreach (var feature in selectedFeaturesEntities)
        {
            var roomFeature = new RoomFeature()
            {
                Feature = feature,
                Room = room
            };

            dbContext.RoomsFeatures.Add(roomFeature);
        }

        await dbContext.SaveChangesAsync();

        return room.Hotel.PublicId;
    }

    public async Task<Guid> DeleteAsync(int userId, Guid roomId)
    {
        bool isUserFound = await dbContext.Users
            .AnyAsync(u => u.Id == userId);

        if (isUserFound == false)
        {
            throw new InvalidModelDataException(UserErrors.NotFound);
        }

        var room = await dbContext.Rooms
            .Include(r => r.Hotel)
            .Include(r => r.Hotel.Manager)
            .SingleOrDefaultAsync(r => r.PublicId == roomId);

        if (room == null)
        {
            throw new InvalidModelDataException(HotelErrors.NotFound);
        }

        if (room.Hotel.Manager.UserId != userId)
        {
            throw new InvalidModelDataException(HotelErrors.NotManager);
        }

        room.IsActive = false;

        await dbContext.SaveChangesAsync();

        return room.Hotel.PublicId;
    }
}
