namespace HotBooking.Core.DTOs.HotelDtos;
public class PreviewHotelDto
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string HotelName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public int StarRating { get; set; }

    public double AverageRating  { get; set; }

    public int ReviewsCount { get; set; }
}
