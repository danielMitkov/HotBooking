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

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<HotelFacility>()
            .HasKey(x => new { x.HotelId, x.FacilityId });

        modelBuilder
            .Entity<RoomFeature>()
            .HasKey(x => new { x.RoomId, x.FeatureId });

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
