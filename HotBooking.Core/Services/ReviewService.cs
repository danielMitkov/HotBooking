using HotBooking.Core.DTOs.ReviewDtos;
using HotBooking.Core.Enums;
using HotBooking.Core.Interfaces;
using HotBooking.Data;
using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Core.Services;

public class ReviewService : IReviewService
{
    private readonly HotBookingDbContext dbContext;
    private readonly UserManager<ApplicationUser> userManager;

    public ReviewService(
        HotBookingDbContext dbContext,
        UserManager<ApplicationUser> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
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

        if (inputDto.UserId != null)
        {
            int userId = int.Parse(inputDto.UserId);

            queryReviews = queryReviews
                .OrderByDescending(r => r.UserId == userId)
                .ThenByDescending(r => r.ReviewedOn);
        }
        else
        {
            queryReviews = queryReviews
            .OrderByDescending(r => r.ReviewedOn);
        }

        int skipAmount = (currentPage - 1) * inputDto.PageSize;

        queryReviews = queryReviews
            .Skip(skipAmount)
            .Take(inputDto.PageSize);

        IEnumerable<ReviewDetailsDto> reviewDto;

        if (inputDto.UserId != null)
        {
            int userId = int.Parse(inputDto.UserId);

            reviewDto = await queryReviews
                .Select(r => new ReviewDetailsDto(
                    r.UserId == userId,
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
        }
        else
        {
            reviewDto = await queryReviews
                .Select(r => new ReviewDetailsDto(
                    false,
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
        }

        BrowseReviewsOutputDto outputDto = new(reviewDto, totalPages, reviewsCount);

        return outputDto;
    }

    public async Task<bool> AddReviewAsync(AddReviewInputDto inputDto)
    {
        var hotel = await dbContext.Hotels
            .FirstOrDefaultAsync(h => h.PublicId == inputDto.HotelId);

        if (hotel == null)
        {
            return false;
        }

        var user = await userManager.FindByIdAsync(inputDto.UserId);

        if (user == null)
        {
            return false;
        }

        var userId = int.Parse(inputDto.UserId);

        var lastUserBookingForHotel = await dbContext.Bookings
            .Where(b => b.UserId == userId && b.Hotel.PublicId == inputDto.HotelId)
            .OrderByDescending(b => b.CheckOut)
            .FirstOrDefaultAsync();

        if (lastUserBookingForHotel == null)
        {
            return false;
        }

        Review review = new()
        {
            RatingScore = inputDto.RatingScore,
            Title = inputDto.Title,
            Comment = inputDto.Comment,
            HotelId = hotel.Id,
            BookingId = lastUserBookingForHotel.Id,
            UserId = userId,
        };

        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();

        return true;
    }
}
