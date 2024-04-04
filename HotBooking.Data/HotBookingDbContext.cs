using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Data;

public class HotBookingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public HotBookingDbContext()
    {
    }

    public HotBookingDbContext(DbContextOptions<HotBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; } = null!;

    public virtual DbSet<Room> Rooms { get; set; } = null!;

    public virtual DbSet<Booking> Bookings { get; set; } = null!;

    public virtual DbSet<Review> Reviews { get; set; } = null!;

    public virtual DbSet<Manager> Managers { get; set; } = null!;

    public virtual DbSet<Feature> Features { get; set; } = null!;

    public virtual DbSet<Facility> Facilities { get; set; } = null!;

    public virtual DbSet<HotelImageUrl> HotelImageUrls { get; set; } = null!;

    public virtual DbSet<RoomImageUrl> RoomImageUrls { get; set; } = null!;

    public virtual DbSet<RoomFeature> RoomsFeatures { get; set; } = null!;

    public virtual DbSet<HotelFacility> HotelsFacilities { get; set; } = null!;

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

        DataSeeder seeder = new DataSeeder();

        modelBuilder.Entity<Facility>().HasData(seeder.Facilities);
        modelBuilder.Entity<ApplicationUser>().HasData(seeder.ApplicationUsers);
        modelBuilder.Entity<Manager>().HasData(seeder.Managers);
        modelBuilder.Entity<Hotel>().HasData(seeder.Hotels);
        modelBuilder.Entity<HotelFacility>().HasData(seeder.HotelFacilities);
        modelBuilder.Entity<HotelImageUrl>().HasData(seeder.HotelImageUrls);
        modelBuilder.Entity<Room>().HasData(seeder.Rooms);
        modelBuilder.Entity<Booking>().HasData(seeder.Bookings);
        modelBuilder.Entity<Review>().HasData(seeder.Reviews);

        base.OnModelCreating(modelBuilder);
    }
}
