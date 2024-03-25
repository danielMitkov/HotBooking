using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class HotelImageUrlConfiguration : IEntityTypeConfiguration<HotelImageUrl>
{
    public const int ThreeWhileHousesId = 1;
    public const int MultiHotelsId = 2;

    public void Configure(EntityTypeBuilder<HotelImageUrl> builder)
    {
        builder.HasData(GetImageUrls());
    }

    private HotelImageUrl[] GetImageUrls()
    {
        return new HotelImageUrl[]
        {
            new HotelImageUrl()
            {
                Id = ThreeWhileHousesId,
                Url = "https://www.w3schools.com/html/pic_trulli.jpg",
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId
            },
            new HotelImageUrl()
            {
                Id = MultiHotelsId,
                Url = "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg",
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId
            }
        };
    }
}
