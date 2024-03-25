namespace HotBooking.Core.DTOs.HotelDtos;
public class BrowseHotelsOutputDto
{
    public ICollection<PreviewHotelDto> SelectedHotels { get; set; } = new List<PreviewHotelDto>();

    public int TotalPages { get; set; }
}
