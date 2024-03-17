namespace HotBooking.Web.Models.HotelViewModels;

public class PreviewHotelViewModel
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string HotelName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public int StarRating { get; set; }

    public decimal AverageRating { get; set; }

    public int ReviewsCount { get; set; }
}
