using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotBooking.Data.Models;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser()
    {
        PublicId = Guid.NewGuid();

        Bookings = new HashSet<Booking>();
        Reviews = new HashSet<Review>();
    }

    [Required]
    public Guid PublicId { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
