using HotBooking.Data.Configurations;
using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Data;

public class HotBookingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
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

    public DbSet<HotelImageUrl> HotelImageUrls { get; set; } = null!;

    public DbSet<RoomImageUrl> RoomImageUrls { get; set; } = null!;

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
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex(nameof(BaseEntity.PublicId))
                    .IsUnique();
            }

            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        modelBuilder.ApplyConfiguration(new FacilityConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ManagerConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new HotelFacilityConfiguration());
        modelBuilder.ApplyConfiguration(new HotelImageUrlConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
