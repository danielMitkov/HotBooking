using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasData(GetRooms());
    }

    private Room[] GetRooms()
    {
        return new Room[]
        {
            new Room
            {
                Id = 1,
                Title = "Cozy Retreat",
                Description = "A comfortable room for a relaxing stay.",
                BedsCount = 2,
                RoomSizeSquareMeters = 25,
                PricePerNight = 75.50m,
                HotelId = 1
            },
            new Room
            {
                Id = 2,
                Title = "Executive Suite",
                Description = "Luxurious suite with modern amenities.",
                BedsCount = 1,
                RoomSizeSquareMeters = 40,
                PricePerNight = 120.75m,
                HotelId = 1
            },
            new Room
            {
                Id = 3,
                Title = "Family Getaway",
                Description = "Spacious room suitable for families.",
                BedsCount = 3,
                RoomSizeSquareMeters = 35,
                PricePerNight = 95.25m,
                HotelId = 2
            },
            new Room
            {
                Id = 4,
                Title = "Ocean View Paradise",
                Description = "Enjoy breathtaking views of the ocean.",
                BedsCount = 1,
                RoomSizeSquareMeters = 30,
                PricePerNight = 110.00m,
                HotelId = 2
            },
            new Room
            {
                Id = 5,
                Title = "Mountain Lodge",
                Description = "Escape to a cozy lodge in the mountains.",
                BedsCount = 2,
                RoomSizeSquareMeters = 28,
                PricePerNight = 85.80m,
                HotelId = 2
            }
        };
    }
}
