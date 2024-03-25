using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public const int CozyRetreatId = 1;
    public const int ExecutiveSuiteId = 2;
    public const int FamilyGetawayId = 3;
    public const int OceanViewParadiseId = 4;
    public const int MountainLodgeId = 5;

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
                Id = CozyRetreatId,
                Title = "Cozy Retreat",
                Description = "A comfortable room for a relaxing stay.",
                BedsCount = 2,
                RoomSizeSquareMeters = 25,
                PricePerNight = 75.50m,
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId
            },
            new Room
            {
                Id = ExecutiveSuiteId,
                Title = "Executive Suite",
                Description = "Luxurious suite with modern amenities.",
                BedsCount = 1,
                RoomSizeSquareMeters = 40,
                PricePerNight = 120.75m,
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId
            },
            new Room
            {
                Id = FamilyGetawayId,
                Title = "Family Getaway",
                Description = "Spacious room suitable for families.",
                BedsCount = 3,
                RoomSizeSquareMeters = 35,
                PricePerNight = 95.25m,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            },
            new Room
            {
                Id = OceanViewParadiseId,
                Title = "Ocean View Paradise",
                Description = "Enjoy breathtaking views of the ocean.",
                BedsCount = 1,
                RoomSizeSquareMeters = 30,
                PricePerNight = 110.00m,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            },
            new Room
            {
                Id = MountainLodgeId,
                Title = "Mountain Lodge",
                Description = "Escape to a cozy lodge in the mountains.",
                BedsCount = 2,
                RoomSizeSquareMeters = 28,
                PricePerNight = 85.80m,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            }
        };
    }
}
