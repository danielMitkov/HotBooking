namespace HotBooking.Core.DTOs.HotelDtos;
public class BrowseHotelsOutputDto
{
    public ICollection<PreviewHotelDto> SelectedHotels { get; set; } = null!;

    public int TotalPages { get; set; }
}
