using HotBooking.Core.DTOs.ReviewDtos;
using HotBooking.Core.Interfaces;
using HotBooking.Web.Models.ReviewViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class ReviewController : Controller
{
    public const string Name = "Review";

    private readonly IReviewService reviewService;

    public ReviewController(IReviewService reviewService)
    {
        this.reviewService = reviewService;
    }

    [Route("Review/All/{page?}")]
    public async Task<IActionResult> All(Guid hotelId, int page = 1)
    {
        BrowseReviewsInputDto inputDto = new(hotelId, page, 2);

        BrowseReviewsOutputDto? outputDto = await reviewService.GetReviewsForHotel(inputDto);

        if (outputDto == null)
        {
            TempData["Error"] = "Hotel Not Found!";
            return BadRequest();
        }

        BrowseReviewsViewModel model = new()
        {
            Page = page,
            ReviewsCount = outputDto.ReviewsCount,
            Pager = new(outputDto.TotalPagesCount, page),
            Reviews = outputDto.Reviews
        };

        return View(model);
    }
}
