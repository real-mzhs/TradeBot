using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Dtos.CommonDtos;
using UserService.Domain.Dtos.UserDtos;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Entities;

namespace UserService.Domain.Services;

public class AppUserService(
    UserManager<AppUserIdentity> userManager,
    IEmailService emailService,
    IUserConfirmationService userConfirmationService,
    IMapper mapper) : IAppUserService
{
    public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
    {
        var users = await userManager.Users.ToListAsync();
        return mapper.Map<IEnumerable<GetUserDto>>(users);
    }

    public async Task<GetUserDto?> GetUserByIdAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        return mapper.Map<GetUserDto>(user);
    }

    public async Task<GetUserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var existingUser = await userManager.FindByEmailAsync(createUserDto.Email);
        if (existingUser is not null)
            throw new InvalidOperationException("User with this email already exists.");

        var userEntity = mapper.Map<AppUserIdentity>(createUserDto);
        userEntity.UserName = createUserDto.Email;

        var result = await userManager.CreateAsync(userEntity, createUserDto.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException(
                $"Failed to create user. Details: {string.Join("; ", result.Errors.Select(e => e.Description))}");

        var code = await userConfirmationService.GenerateConfirmationCodeAsync(userEntity.Id);
        
        await emailService.SendEmailAsync(new CreateEmailDto
        {
            Email = userEntity.Email,
            Subject = "Confirm your account",
            Message = $"Here is your confirmation code: {code}"
        });

        return mapper.Map<GetUserDto>(userEntity);
    }


    public async Task<bool> UpdateUserAsync(string id, CreateUserDto createUserDto)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user is null)
            return false;

        mapper.Map(createUserDto, user);

        var result = await userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user is null)
            return false;

        var result = await userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}
