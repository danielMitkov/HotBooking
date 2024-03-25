using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public const int ChilworthLondonPaddingtonCozyRetreatId = 1;
    public const int ChilworthLondonPaddingtonExecutiveSuiteId = 2;
    public const int KempinskiHotelGrandArenaFamilyGetawayId = 3;
    public const int KempinskiHotelGrandArenaOceanViewParadiseId = 4;
    public const int KempinskiHotelGrandArenaMountainLodgeId = 5;

    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasData(GetBookings());
    }

    private Booking[] GetBookings()
    {
        return new Booking[]
        {
            new Booking
            {
                Id = ChilworthLondonPaddingtonCozyRetreatId,
                CheckIn = new DateTime(2023, 5, 1),
                CheckOut = new DateTime(2023, 5, 5),
                AdultsCount = 2,
                UserId = ApplicationUserConfiguration.NormalId,
                RoomId = RoomConfiguration.CozyRetreatId,
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId
            },
            new Booking
            {
                Id = ChilworthLondonPaddingtonExecutiveSuiteId,
                CheckIn = new DateTime(2023, 6, 10),
                CheckOut = new DateTime(2023, 6, 15),
                AdultsCount = 3,
                UserId = ApplicationUserConfiguration.NormalId,
                RoomId = RoomConfiguration.ExecutiveSuiteId,
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId
            },
            new Booking
            {
                Id = KempinskiHotelGrandArenaFamilyGetawayId,
                CheckIn = new DateTime(2023, 7, 20),
                CheckOut = new DateTime(2023, 7, 25),
                AdultsCount = 1,
                UserId = ApplicationUserConfiguration.SecondUserId,
                RoomId = RoomConfiguration.FamilyGetawayId,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            },
            new Booking
            {
                Id = KempinskiHotelGrandArenaOceanViewParadiseId,
                CheckIn = new DateTime(2023, 8, 5),
                CheckOut = new DateTime(2023, 8, 10),
                AdultsCount = 4,
                UserId = ApplicationUserConfiguration.SecondUserId,
                RoomId = RoomConfiguration.OceanViewParadiseId,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            },
            new Booking
            {
                Id = KempinskiHotelGrandArenaMountainLodgeId,
                CheckIn = new DateTime(2023, 9, 15),
                CheckOut = new DateTime(2023, 9, 20),
                AdultsCount = 2,
                UserId = ApplicationUserConfiguration.SecondUserId,
                RoomId = RoomConfiguration.MountainLodgeId,
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            }
        };
    }
}
