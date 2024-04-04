using HotBooking.Core.Interfaces;
using HotBooking.Core.Interfaces.ValidationInterfaces;
using HotBooking.Core.Services;
using HotBooking.Core.Services.ValidationServices;
using HotBooking.Data;
using HotBooking.Data.Common;
using HotBooking.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHotelsService, HotelsService>();

        services.AddScoped<IHotelValidationService, HotelValidationService>();
        services.AddScoped<IBookingValidationService, BookingValidationService>();

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<HotBookingDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IDbContext, Repository>();

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<HotBookingDbContext>();

        return services;
    }
}
