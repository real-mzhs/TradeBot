using UserService.Domain.Dtos.UserDtos;

namespace UserService.Domain.Interfaces;

public interface IAppUserService
{
    public Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
    public Task<GetUserDto?> GetUserByIdAsync(string userId);
    public Task<GetUserDto> CreateUserAsync(CreateUserDto createUserDto);
    public Task<bool> UpdateUserAsync(string id, CreateUserDto createUserDto);
    public Task<bool> DeleteUserAsync(string userId); 

}
