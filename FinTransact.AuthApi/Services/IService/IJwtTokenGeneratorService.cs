using FinTransact.AuthApi.Models;

namespace FinTransact.AuthApi.Services.IService;

public interface IJwtTokenGeneratorService
{
 string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}
