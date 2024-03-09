using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData(GetHotels());
    }

    private Hotel[] GetHotels()
    {
        return new Hotel[]
        {
            new Hotel()
            {
                Id = 1,
                HotelName = "The Chilworth London Paddington",
                Description = "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.",
                StreetAddress = "Westminster Borough",
                CityName = "London",
                CountryName = "United Kingdom",
                StarRating = 5,
                ManagerId = 1
            },
            new Hotel()
            {
                Id = 2,
                HotelName = "Kempinski Hotel Grand Arena Bansko",
                Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
                StreetAddress = "#96 Pirin Street",
                CityName = "Bansko",
                CountryName = "Bulgaria",
                StarRating = 4,
                ManagerId = 1
            }
        };
    }
}
