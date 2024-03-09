using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotBooking.Data.Configurations;
public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
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
                Id = 1,
                PhoneNumber = "08812345678",
                UserId = "409a1fe1-a017-4e11-94fb-7c638937c52d"
            }
        };
    }
}
