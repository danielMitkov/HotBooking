using HotBooking.Core.Exceptions;
using HotBooking.Core.Interfaces;
using HotBooking.Core.Models.DTOs.BookingDtos;
using HotBooking.Web.Extensions;
using HotBooking.Web.Models;
using HotBooking.Web.Models.BookingViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotBooking.Web.Controllers;

public class BookingController : BaseController
{
    public const string Name = "Booking";

    private readonly ILogger<BookingController> logger;
    private readonly IBookingService bookingService;

    public BookingController(
        ILogger<BookingController> logger,
        IBookingService bookingService)
    {
        this.logger = logger;
        this.bookingService = bookingService;
    }

    [Route("Booking/Add/{roomId}")]
    public async Task<IActionResult> Add(Guid roomId, SearchHotelsViewModel search)
    {
        var addDto = new BookingAddDto(
            User.GetId(),
            roomId,
            search.CheckInDate,
            search.CheckOutDate,
            search.AdultsCount);

        try
        {
            await bookingService.AddAsync(addDto);

            return RedirectToAction(nameof(List));
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;

            return RedirectToAction(nameof(HotelsController.List),
                HotelsController.Name,
                new { searchModel = search });
        }
    }

    public async Task<IActionResult> List()
    {
        var bookings = (await bookingService.GetBookingsAsync(User.GetId()))
                .Select(b => new BookingListViewModel()
                {
                    BookingPublicId = b.BookingPublicId,
                    RoomImageUrl = b.RoomImageUrl,
                    CreatedOn = b.CreatedOn,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    AdultsCount = b.AdultsCount,
                    RoomTitle = b.RoomTitle,
                    HotelName = b.HotelName,
                    HotelLocation = b.HotelLocation,
                    Status = b.Status
                })
                .ToList();

        return View(bookings);
    }

    public async Task<IActionResult> Cancel(Guid id)
    {
        try
        {
            await bookingService.CancelAsync(id);
        }
        catch (InvalidModelDataException ex)
        {
            logger.LogWarning(ex, DateTime.Now.ToString());
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(List));
    }
}
