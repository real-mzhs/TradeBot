using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Dtos.UserDtos;
using UserService.Domain.Interfaces;

namespace UserService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IAppUserService userService) : ControllerBase
{
    [HttpGet("{userId}")]
    [Authorize]
    public async Task<ActionResult<GetUserDto>> GetUserById(string userId)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (currentUserId != userId)
            return Forbid();
        
        var result = await userService.GetUserByIdAsync(userId);
        if (result is not null) return Ok(result);

        return NotFound($"User with ID: {userId} not found.");
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await userService.CreateUserAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error creating user. Detail: {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateUser(string id, [FromBody] CreateUserDto userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Model not valid.");

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (currentUserId != id)
            return Forbid();

        var result = await userService.UpdateUserAsync(id, userDto);

        if (result)
            return Ok("User updated successfully.");

        return BadRequest("Error updating user.");
    }

    [HttpDelete("{userId}")]
    [Authorize]
    public async Task<ActionResult> DeleteUser(string userId)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (currentUserId != userId)
            return Forbid();

        var result = await userService.DeleteUserAsync(userId);

        if (result)
            return NoContent();
        
        return BadRequest($"User with ID: {userId} could not be deleted.");
    } 
}
