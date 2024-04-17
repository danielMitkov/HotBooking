using HotBooking.Core.ErrorMessages;
using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.ReviewDtos;
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

    public async Task<ReviewPreviewDto> GetReviewAsync(Guid reviewPublicId)
    {
        var review = await GetByPublicIdAsync(reviewPublicId);

        var editDto = new ReviewPreviewDto(
            review.RatingScore,
            review.Title,
            review.Comment);

        return editDto;
    }

    public async Task<ReviewBrowseOutputDto> GetReviewsForHotelAsync(BrowseReviewsInputDto inputDto)
    {
        var queryReviews = dbContext.Reviews
            .Where(r => r.Hotel.PublicId == inputDto.HotelId);

        var reviewsCount = await queryReviews.CountAsync();

        if (reviewsCount == 0)
        {
            bool canYouAddReview = false;

            if ((await GetLastUserBookingForHotel(inputDto.UserId, inputDto.HotelId)) != null)
            {
                canYouAddReview = true;
            }

            return new ReviewBrowseOutputDto(
                canYouAddReview,
                new List<ReviewDetailsDto>(),
                0,
                0);
        }

        var totalPages = (int)Math.Ceiling(reviewsCount / (decimal)inputDto.PageSize);

        if (inputDto.CurrentPage < 1 || inputDto.CurrentPage > totalPages)
        {
            throw new PageOutOfRangeException(totalPages);
        }

        queryReviews = queryReviews
                .OrderByDescending(r => r.AuthorId == inputDto.UserId)
                .ThenByDescending(r => r.ReviewedOn);

        var skipAmount = (inputDto.CurrentPage - 1) * inputDto.PageSize;

        queryReviews = queryReviews
            .Skip(skipAmount)
            .Take(inputDto.PageSize);

        var reviewsDto = await queryReviews
            .Select(r => new ReviewDetailsDto(
                r.AuthorId == inputDto.UserId,
                r.PublicId,
                r.RatingScore,
                r.Title,
                r.Comment,
                r.ReviewedOn,
                r.Booking!.CheckIn,
                r.Booking.CheckOut,
                r.Booking.AdultsCount,
                r.Booking.Room.Title
            ))
            .ToListAsync();

        bool canAddReview = false;

        var lastUserBookingForHotel = await GetLastUserBookingForHotel(inputDto.UserId, inputDto.HotelId);

        bool containsMyReview = reviewsDto.Any(r => r.IsMyReview == true);

        if (containsMyReview == false && lastUserBookingForHotel != null)
        {
            canAddReview = true;
        }

        var outputDto = new ReviewBrowseOutputDto(canAddReview, reviewsDto, totalPages, reviewsCount);

        return outputDto;
    }

    public async Task AddReviewAsync(ReviewAddDto addDto)
    {
        bool hasReviewAlready = await dbContext.Reviews
            .AnyAsync(r => r.AuthorId == addDto.UserId && r.Hotel.PublicId == addDto.HotelPublicId);

        if (hasReviewAlready == true)
        {
            throw new InvalidModelDataException(ReviewErrors.AlreadyHasReview);
        }

        var lastUserBookingForHotel = await GetLastUserBookingForHotel(addDto.UserId, addDto.HotelPublicId);

        if (lastUserBookingForHotel == null)
        {
            throw new InvalidModelDataException(BookingErrors.NotFound);
        }

        var review = new Review()
        {
            RatingScore = addDto.Score,
            Title = addDto.Title,
            Comment = addDto.Comment,
            HotelId = lastUserBookingForHotel.HotelId,
            BookingId = lastUserBookingForHotel.Id,
            AuthorId = addDto.UserId,
        };

        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid reviewPublicId, int userId)
    {
        var review = await GetByPublicIdAsync(reviewPublicId);

        ValidateReviewAuthor(review.AuthorId, userId);

        dbContext.Reviews.Remove(review);

        await dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(ReviewEditDto editDto)
    {
        await ValidateUserExists(editDto.UserId);

        var review = await GetByPublicIdAsync(editDto.ReviewPublicId);

        ValidateReviewAuthor(review.AuthorId, editDto.UserId);

        int? lastUserBookingId = await dbContext.Bookings
            .Where(b => b.IsActive)
            .Where(b => b.UserId == editDto.UserId && b.HotelId == review.HotelId)
            .OrderByDescending(b => b.CheckOut)
            .Select(b => b.Id)
            .FirstOrDefaultAsync();

        if (lastUserBookingId == null)
        {
            throw new InvalidModelDataException(BookingErrors.NotFound);
        }

        review.BookingId = (int)lastUserBookingId;

        review.RatingScore = editDto.Score;
        review.Title = editDto.Title;
        review.Comment = editDto.Comment;
        review.ReviewedOn = DateTime.Now;

        await dbContext.SaveChangesAsync();
    }

    private async Task<Booking?> GetLastUserBookingForHotel(int userId, Guid hotelId)
    {
        bool isUserFound = await dbContext.Users
            .Where(u => u.IsDeleted == false)
            .AnyAsync(u => u.Id == userId);

        if (isUserFound == false)
        {
            return null;
        }

        bool isHotelFound = await dbContext.Hotels
            .Where(h => h.IsActive)
            .AnyAsync(h => h.PublicId == hotelId);

        if (isHotelFound == false)
        {
            throw new InvalidModelDataException(HotelErrors.NotFound);
        }

        var lastUserBookingForHotel = await dbContext.Bookings
            .Where(b => b.IsActive)
            .Where(b => b.UserId == userId && b.Hotel.PublicId == hotelId)
            .Include(b => b.Review)
            .OrderByDescending(b => b.CheckOut)
            .FirstOrDefaultAsync();

        return lastUserBookingForHotel;
    }

    private async Task<Review> GetByPublicIdAsync(Guid reviewPublicId)
    {
        var review = await dbContext.Reviews
            .SingleOrDefaultAsync(r => r.PublicId == reviewPublicId);

        if (review == null)
        {
            throw new InvalidModelDataException(ReviewErrors.NotFound);
        }

        return review;
    }

    private void ValidateReviewAuthor(int authorId, int userId)
    {
        if (authorId != userId)
        {
            throw new InvalidModelDataException(ReviewErrors.NotTheAuthorOfReview);
        }
    }

    private async Task ValidateUserExists(int userId)
    {
        bool isUserFound = await dbContext.Users
            .Where(u => u.IsDeleted == false)
            .Where(u => u.Id == userId)
            .Select(u => true)
            .SingleOrDefaultAsync();

        if (isUserFound == false)
        {
            throw new InvalidModelDataException(UserErrors.NotFound);
        }
    }
}
