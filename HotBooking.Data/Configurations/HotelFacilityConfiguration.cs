using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class HotelFacilityConfiguration : IEntityTypeConfiguration<HotelFacility>
{
    public void Configure(EntityTypeBuilder<HotelFacility> builder)
    {
        builder.HasData(GetHotelFacilities());
    }

    private HotelFacility[] GetHotelFacilities()
    {
        return new HotelFacility[]
        {
            new HotelFacility()
            {
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                FacilityId = FacilityConfiguration.WiFiId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                FacilityId = FacilityConfiguration.ParkingId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                FacilityId = FacilityConfiguration.SpaId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                FacilityId = FacilityConfiguration.FitnessId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                FacilityId = FacilityConfiguration.WiFiId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                FacilityId = FacilityConfiguration.ParkingId
            },
            new HotelFacility()
            {
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                FacilityId = FacilityConfiguration.RestaurantId
            },
        };
    }
}
