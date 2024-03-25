using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public const int ExcellentProductId = 1;
    public const int AverageExperienceId = 2;
    public const int PoorQualityId = 3;
    public const int GoodValueId = 4;
    public const int BestProductEverId = 5;

    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(GetReviews());
    }

    private Review[] GetReviews()
    {
        return new Review[]
        {
            new Review
            {
                Id = ExcellentProductId,
                RatingScore = 5,
                Title = "Excellent Product",
                Comment = "I love this product! It's exactly what I needed.",
                ReviewedOn = new DateTime(2023, 4, 1),
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                BookingId = BookingConfiguration.ChilworthLondonPaddingtonCozyRetreatId,
                UserId = ApplicationUserConfiguration.NormalId
            },
            new Review
            {
                Id = AverageExperienceId,
                RatingScore = 3,
                Title = "Average Experience",
                Comment = "The product was okay, but could be better.",
                ReviewedOn = new DateTime(2023, 3, 28),
                HotelId = HotelConfiguration.ChilworthLondonPaddingtonId,
                BookingId = BookingConfiguration.ChilworthLondonPaddingtonExecutiveSuiteId,
                UserId = ApplicationUserConfiguration.NormalId
            },
            new Review
            {
                Id = PoorQualityId,
                RatingScore = 1,
                Title = "Poor Quality",
                Comment = "I was very disappointed with this product.",
                ReviewedOn = new DateTime(2023, 3, 27),
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                BookingId = BookingConfiguration.KempinskiHotelGrandArenaFamilyGetawayId,
                UserId = ApplicationUserConfiguration.SecondUserId
            },
            new Review
            {
                Id = GoodValueId,
                RatingScore = 4,
                Title = "Good Value",
                Comment = "I got my money's worth with this product.",
                ReviewedOn = new DateTime(2023, 3, 26),
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                BookingId = BookingConfiguration.KempinskiHotelGrandArenaOceanViewParadiseId,
                UserId = ApplicationUserConfiguration.SecondUserId
            },
            new Review
            {
                Id = BestProductEverId,
                RatingScore = 5,
                Title = "Best Product Ever",
                Comment = "This product is amazing! Highly recommended.",
                ReviewedOn = new DateTime(2023, 3, 25),
                HotelId = HotelConfiguration.KempinskiHotelGrandArenaId,
                BookingId = BookingConfiguration.KempinskiHotelGrandArenaMountainLodgeId,
                UserId = ApplicationUserConfiguration.SecondUserId
            }
        };
    }
}
