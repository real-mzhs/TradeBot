using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Dtos.JwtDtos;
using UserService.Domain.Interfaces;
using UserService.Domain.Interfaces.JwtContracts;
using UserService.Infrastructure.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IConfiguration configuration,
    UserManager<AppUserIdentity> userManager,
    IUserConfirmationService userConfirmationService,
    ITokenService tokenService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginStore([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new ArgumentException("Bad credentials");

            var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                throw new ArgumentException("Bad credentials");

            if (!user.EmailConfirmed)
                throw new ArgumentException("Email not confirmed, please check your email for confirmation.");

            var auth = tokenService.CreateToken(user);

            user.RefreshToken = tokenService.RefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            auth.RefreshToken = user.RefreshToken;

            await userManager.UpdateAsync(user);
            return Ok(auth);
        }
        catch (Exception ex)
        {
            return BadRequest("An unexpected error occurred while logging in");
        }
    }

    [HttpGet]
    [Route("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string code)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
            return BadRequest("User not found");

        try
        {
            await userConfirmationService.ValidateConfirmationCodeAsync(new ConfirmationCode { Code = code, UserId = userId });
            await userManager.ConfirmEmailAsync(user, code);

            return Ok("Email confirmed successfully");
        }
        catch (Exception)
        {
            return BadRequest("Error confirming user, invalid code.");
        }
    }

    [HttpGet]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromHeader] string token, [FromHeader] string refreshToken)
    {
        try
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))
                return BadRequest("Token or refreshToken is missing");

            var principal = tokenService.GetPrincipalFromExpiredToken(token);

            if (principal == null)
                return BadRequest("Invalid client request");

            var emailClaim = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(emailClaim))
                return BadRequest("Invalid client request");

            var user = await userManager.FindByEmailAsync(emailClaim);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return BadRequest("Invalid access token or refresh token");

            var response = tokenService.CreateToken(user);
            response.RefreshToken = user.RefreshToken;
            response.ValidTo = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:ExpirationMinutes"])).ToString(CultureInfo.InvariantCulture);

            return Ok(response);
        }
        catch (Exception)
        {
            return StatusCode(500, "An unexpected error occurred");
        }
    }
}
