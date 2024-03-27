using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public const int SpaId = 1;
    public const int ParkingId = 2;
    public const int WiFiId = 3;
    public const int RestaurantId = 4;
    public const int FitnessId = 5;

    public void Configure(EntityTypeBuilder<Facility> builder)
    {   
        builder.HasData(GetFacilities());
    }

    private Facility[] GetFacilities()
    {
        return new Facility[]
        {
            new Facility()
            {
                Id = SpaId,
                Name = "Spa",
                SvgTag = string.Empty
            },
            new Facility()
            {
                Id = ParkingId,
                Name = "Parking",
                SvgTag = string.Empty
            },
            new Facility()
            {
                Id = WiFiId,
                Name = "Free WiFi",
                SvgTag = string.Empty
            },
            new Facility()
            {
                Id = RestaurantId,
                Name = "Restaurant",
                SvgTag = string.Empty
            },
            new Facility()
            {
                Id = FitnessId,
                Name = "Fitness center",
                SvgTag = string.Empty
            },
        };
    }
}
