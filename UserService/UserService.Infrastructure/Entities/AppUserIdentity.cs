using Microsoft.AspNetCore.Identity;

namespace UserService.Infrastructure.Entities;

public class AppUserIdentity : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; } 
}
