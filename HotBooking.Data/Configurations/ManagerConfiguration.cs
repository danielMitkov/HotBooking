using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public const int FirstId = 1;

    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasData(GetManagers());
    }

    private Manager[] GetManagers()
    {
        return new Manager[]
        {
            new Manager()
            {
                Id = FirstId,
                PhoneNumber = "08812345678",
                UserId = ApplicationUserConfiguration.TobeManagerId
            }
        };
    }
}
