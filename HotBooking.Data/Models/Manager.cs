namespace HotBooking.Data.Models;
public class Manager
{
    public int Id { get; set; }
    public string UserId { get; set; }

    public int HotelId { get; set; }

    public Hotel Hotel { get; set; } = null!;
}
