using AutoMapper;
using UserService.Domain.Dtos.UserDtos;
using UserService.Infrastructure.Entities;

namespace UserService.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, AppUserIdentity>();
        CreateMap<AppUserIdentity, GetUserDto>();
    } 
}
