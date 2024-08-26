namespace FinTransact.AuthApi.Models;

public class DefaultUserOptions
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string Role { get; set; } = nameof(StaticData.DefaultRoles.SUPER_ADMIN);
}
