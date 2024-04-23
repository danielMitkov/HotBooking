using HotBooking.Core.Interfaces;
using HotBooking.Core.Services;
using HotBooking.Data;
using HotBooking.Data.Models;
using HotBooking.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Web.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHotelsService, HotelsService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<IManagerService, ManagerService>();

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'HotBookingDbContextConnection' not found.");

        services.AddDbContext<HotBookingDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<HotBookingDbContext>();

        return services;
    }

    public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        if (userManager != null && roleManager != null && await roleManager
            .RoleExistsAsync(AdminConstants.AdminRoleName) == false)
        {
            var role = new IdentityRole<int>(AdminConstants.AdminRoleName);
            await roleManager.CreateAsync(role);

            var admin = await userManager.FindByEmailAsync("guest@mail.com");

            if (admin != null)
            {
                await userManager.AddToRoleAsync(admin, role.Name);
            }
        }

    }
}
