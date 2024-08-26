using System.Runtime.CompilerServices;
using FinTransact.AuthApi.Data;
using FinTransact.AuthApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinTransact.AuthApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAuthentication(this IServiceCollection service)
    {
        // Todo
    }

    public static void ConfigureAuthorization(this IServiceCollection service)
    {
        // Todo
    }
    public static void ConfigureCORS(this IServiceCollection service)
    {
        // Todo
    }


    public static void ConfigureDbContext(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AuthApiDbConnectionString"));
        });
    }

    public static void ConfigureIdentity(this IServiceCollection service)
    {
        service.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}
