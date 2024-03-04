using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Data;
public class HotBookingDbContext : IdentityDbContext<ApplicationUser>
{
    public HotBookingDbContext(DbContextOptions<HotBookingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; } = null!;

    public DbSet<Room> Rooms { get; set; } = null!;

    public DbSet<Booking> Bookings { get; set; } = null!;

    public DbSet<Review> Reviews { get; set; } = null!;

    public DbSet<Manager> Managers { get; set; } = null!;

    public DbSet<Feature> Features { get; set; } = null!;

    public DbSet<Facility> Facilities { get; set; } = null!;

    public DbSet<ImageUrl> ImageUrls { get; set; } = null!;

    public DbSet<RoomFeature> RoomsFeatures { get; set; } = null!;

    public DbSet<HotelFacility> HotelsFacilities { get; set; } = null!;
}
