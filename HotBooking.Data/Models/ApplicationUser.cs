using Microsoft.AspNetCore.Identity;

namespace HotBooking.Data.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
