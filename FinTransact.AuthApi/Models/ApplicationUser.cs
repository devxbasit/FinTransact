using Microsoft.AspNetCore.Identity;

namespace FinTransact.AuthApi.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
