using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserService.Domain.Dtos.JwtDtos;
using UserService.Domain.Interfaces.JwtContracts;
using UserService.Infrastructure.Entities;

namespace UserService.Domain.Services.JwtServices;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public AuthResponse CreateToken(AppUserIdentity user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Sub, user.UserName),
        };

        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"]!,
            audience: configuration["JwtSettings:Audience"]!,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:ExpirationMinutes"])),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                SecurityAlgorithms.HmacSha256));

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new AuthResponse
        {
            Token = tokenString,
            ValidTo = token.ValidTo.ToString(CultureInfo.InvariantCulture)
        };
    }

    public string RefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}
