using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasData(GetApplicationUsers());
    }

    private ApplicationUser[] GetApplicationUsers()
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        var normal = new ApplicationUser()
        {
            Id = "49c62027-4afc-4a6f-89b4-58b946cc51a8",
            UserName = "guest@mail.com",
            NormalizedUserName = "guest@mail.com",
            Email = "guest@mail.com",
            NormalizedEmail = "guest@mail.com"
        };
        normal.PasswordHash = hasher.HashPassword(normal, "secretpass");

        var secondUser = new ApplicationUser()
        {
            Id = "a9dbd6b4-a878-41a6-9da6-8fac71893547",
            UserName = "two@mail.com",
            NormalizedUserName = "two@mail.com",
            Email = "two@mail.com",
            NormalizedEmail = "two@mail.com"
        };
        secondUser.PasswordHash = hasher.HashPassword(secondUser, "otherpass");

        var tobeManager = new ApplicationUser()
        {
            Id = "409a1fe1-a017-4e11-94fb-7c638937c52d",
            UserName = "manager@mail.com",
            NormalizedUserName = "manager@mail.com",
            Email = "manager@mail.com",
            NormalizedEmail = "manager@mail.com"
        };
        tobeManager.PasswordHash = hasher.HashPassword(tobeManager, "managerpass");

        return new ApplicationUser[] { normal, secondUser, tobeManager };
    }
}
