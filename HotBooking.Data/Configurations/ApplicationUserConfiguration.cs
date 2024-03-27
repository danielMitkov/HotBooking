using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public const int NormalId = 1;
    public const int SecondUserId = 2;
    public const int TobeManagerId = 3;

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasData(GetApplicationUsers());
    }

    private ApplicationUser[] GetApplicationUsers()
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        var normal = new ApplicationUser()
        {
            Id = NormalId,
            UserName = "guest@mail.com",
            NormalizedUserName = "guest@mail.com",
            Email = "guest@mail.com",
            NormalizedEmail = "guest@mail.com"
        };
        normal.PasswordHash = hasher.HashPassword(normal, "secretpass");

        var secondUser = new ApplicationUser()
        {
            Id = SecondUserId,
            UserName = "two@mail.com",
            NormalizedUserName = "two@mail.com",
            Email = "two@mail.com",
            NormalizedEmail = "two@mail.com"
        };
        secondUser.PasswordHash = hasher.HashPassword(secondUser, "otherpass");

        var tobeManager = new ApplicationUser()
        {
            Id = TobeManagerId,
            UserName = "manager@mail.com",
            NormalizedUserName = "manager@mail.com",
            Email = "manager@mail.com",
            NormalizedEmail = "manager@mail.com"
        };
        tobeManager.PasswordHash = hasher.HashPassword(tobeManager, "managerpass");

        return new ApplicationUser[] { normal, secondUser, tobeManager };
    }
}
