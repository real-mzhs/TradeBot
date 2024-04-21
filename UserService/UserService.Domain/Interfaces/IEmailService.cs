
using UserService.Domain.Dtos.CommonDtos;

namespace UserService.Domain.Interfaces;

public interface IEmailService
{
    public Task SendEmailAsync(CreateEmailDto emailDto);
}
