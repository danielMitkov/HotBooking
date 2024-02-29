namespace HotBooking.Data.Models;
public class Facility
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IconClassName { get; set; } = null!;

    public string Description { get; set; } = null!;
}
