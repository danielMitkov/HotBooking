using HotBooking.Core.DTOs.ReviewDtos;
using HotBooking.Core.Interfaces;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models.ReviewViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

[Authorize]
public class ReviewController : Controller
{
    public const string Name = "Review";

    private readonly IReviewService reviewService;

    public ReviewController(IReviewService reviewService)
    {
        this.reviewService = reviewService;
    }

    [AllowAnonymous]
    [Route("Review/All/{page?}")]
    public async Task<IActionResult> All(Guid hotelId, int page = 1)
    {
        BrowseReviewsInputDto inputDto = new(User.GetUserId(), hotelId, page, 2);

        BrowseReviewsOutputDto? outputDto = await reviewService.GetReviewsForHotel(inputDto);

        if (outputDto == null)
        {
            TempData["Error"] = "Hotel Not Found!";
            return BadRequest();
        }

        BrowseReviewsViewModel model = new()
        {
            HotelId = hotelId,
            Page = page,
            ReviewsCount = outputDto.ReviewsCount,
            Pager = new(outputDto.TotalPagesCount, page),
            Reviews = outputDto.Reviews
        };

        return View(model);
    }

    public async Task<IActionResult> Add(Guid hotelId)
    {
        FormReviewViewModel model = new()
        {
            HotelId = hotelId
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(FormReviewViewModel model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        AddReviewInputDto inputDto = new(
            User.GetUserId(),
            model.HotelId,
            model.RatingScore,
            model.Title,
            model.Comment);

        bool status = await reviewService.AddReviewAsync(inputDto);

        return View(model);
    }
}
