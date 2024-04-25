using System.Security.Claims;
using UserService.Domain.Dtos.JwtDtos;
using UserService.Infrastructure.Entities;

namespace UserService.Domain.Interfaces.JwtContracts;

public interface ITokenService
{
    public AuthResponse CreateToken(AppUserIdentity user);
    public string RefreshToken();
    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);  
}
