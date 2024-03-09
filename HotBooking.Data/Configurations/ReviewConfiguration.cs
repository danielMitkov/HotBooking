using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
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
                Id = 1,
                RatingScore = 5,
                Title = "Excellent Product",
                Comment = "I love this product! It's exactly what I needed.",
                ReviewedOn = new DateTime(2023, 4, 1),
                HotelId = 1,
                BookingId = 1,
                UserId = "49c62027-4afc-4a6f-89b4-58b946cc51a8"
            },
            new Review
            {
                Id = 2,
                RatingScore = 3,
                Title = "Average Experience",
                Comment = "The product was okay, but could be better.",
                ReviewedOn = new DateTime(2023, 3, 28),
                HotelId = 1,
                BookingId = 2,
                UserId = "49c62027-4afc-4a6f-89b4-58b946cc51a8"
            },
            new Review
            {
                Id = 3,
                RatingScore = 1,
                Title = "Poor Quality",
                Comment = "I was very disappointed with this product.",
                ReviewedOn = new DateTime(2023, 3, 27),
                HotelId = 2,
                BookingId = 3,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547"
            },
            new Review
            {
                Id = 4,
                RatingScore = 4,
                Title = "Good Value",
                Comment = "I got my money's worth with this product.",
                ReviewedOn = new DateTime(2023, 3, 26),
                HotelId = 2,
                BookingId = 4,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547"
            },
            new Review
            {
                Id = 5,
                RatingScore = 5,
                Title = "Best Product Ever",
                Comment = "This product is amazing! Highly recommended.",
                ReviewedOn = new DateTime(2023, 3, 25),
                HotelId = 2,
                BookingId = 5,
                UserId = "a9dbd6b4-a878-41a6-9da6-8fac71893547"
            }
        };
    }
}
