namespace HotBooking.Core.DTOs.HotelDtos;
public class BrowseHotelsInputDto
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public string? City { get; set; }
}
