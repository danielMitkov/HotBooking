using HotBooking.Core.DTOs.ReviewDtos;
using HotBooking.Core.Interfaces;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class ReviewService : IReviewService
{
    private readonly HotBookingDbContext dbContext;

    public ReviewService(HotBookingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<BrowseReviewsOutputDto?> GetReviewsForHotel(BrowseReviewsInputDto inputDto)
    {
        IQueryable<Review> queryReviews = dbContext.Reviews
            .Where(r => r.Hotel.PublicId == inputDto.HotelId);

        int reviewsCount = await queryReviews.CountAsync();

        if (reviewsCount == 0)
        {
            return null;
        }

        int totalPages = (int)Math.Ceiling(reviewsCount / (decimal)inputDto.PageSize);

        int currentPage = inputDto.CurrentPage;

        if (inputDto.CurrentPage < 1 || inputDto.CurrentPage > totalPages)
        {
            currentPage = 1;
        }

        int skipAmount = (currentPage - 1) * inputDto.PageSize;

        queryReviews = queryReviews
            .Skip(skipAmount)
            .Take(inputDto.PageSize);

        IEnumerable<ReviewDetailsDto> reviewDto = await queryReviews
            .Select(r => new ReviewDetailsDto(
                r.RatingScore,
                r.Title,
                r.Comment,
                r.ReviewedOn,
                r.Booking.CheckIn,
                r.Booking.CheckOut,
                r.Booking.AdultsCount,
                r.Booking.Room.Title
            ))
            .ToListAsync();

        BrowseReviewsOutputDto outputDto = new(reviewDto, totalPages, reviewsCount);

        return outputDto;
    }
}
