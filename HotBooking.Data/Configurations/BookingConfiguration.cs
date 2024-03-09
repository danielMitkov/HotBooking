using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
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
                Id = 1,
                CheckIn = new DateTime(2023, 5, 1),
                CheckOut = new DateTime(2023, 5, 5),
                AdultsCount = 2,
                UserId = "49c62027-4afc-4a6f-89b4-58b946cc51a8",
                RoomId = 1,
                HotelId = 1
            },
            new Booking
            {
                Id = 2,
                CheckIn = new DateTime(2023, 6, 10),
                CheckOut = new DateTime(2023, 6, 15),
                AdultsCount = 3,
                UserId = "49c62027-4afc-4a6f-89b4-58b946cc51a8",
                RoomId = 2,
                HotelId = 1
            },
            new Booking
            {
                Id = 3,
                CheckIn = new DateTime(2023, 7, 20),
                CheckOut = new DateTime(2023, 7, 25),
                AdultsCount = 1,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547",
                RoomId = 3,
                HotelId = 2
            },
            new Booking
            {
                Id = 4,
                CheckIn = new DateTime(2023, 8, 5),
                CheckOut = new DateTime(2023, 8, 10),
                AdultsCount = 4,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547",
                RoomId = 4,
                HotelId = 2
            },
            new Booking
            {
                Id = 5,
                CheckIn = new DateTime(2023, 9, 15),
                CheckOut = new DateTime(2023, 9, 20),
                AdultsCount = 2,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547",
                RoomId = 5,
                HotelId = 2
            }
        };
    }
}
