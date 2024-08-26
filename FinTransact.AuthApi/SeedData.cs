using FinTransact.AuthApi.Models;
using Microsoft.AspNetCore.Identity;

namespace FinTransact.AuthApi;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var roleManager = serviceProvider?.GetRequiredService<RoleManager<IdentityRole>>() ?? throw new NullReferenceException($"RoleManager null ref");
        var userManager = serviceProvider?.GetRequiredService<UserManager<ApplicationUser>>() ?? throw new NullReferenceException("UserManager null ref");

        // Adding default roles
        foreach (var role in Enum.GetNames(typeof(StaticData.DefaultRoles)))
        {
            if (!(await roleManager.RoleExistsAsync(role)))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Adding Default User with role
        var defaultUserOptions = configuration.GetSection("DefaultUserOptions")?.Get<DefaultUserOptions>() ?? throw new NullReferenceException("DefaultUserOptions null ref");

        if (await userManager.FindByEmailAsync(defaultUserOptions.Email) is null)
        {
            var newAppUser = new ApplicationUser()
            {
                Name = defaultUserOptions.Name,
                UserName = defaultUserOptions.Username,
                Email = defaultUserOptions.Email,
            };

            await userManager.CreateAsync(newAppUser, password: defaultUserOptions.Password);
            await userManager.AddToRoleAsync(newAppUser, defaultUserOptions.Role);
        }
    }
}
