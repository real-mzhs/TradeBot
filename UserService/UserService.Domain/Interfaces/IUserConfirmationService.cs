using UserService.Infrastructure.Entities;

namespace UserService.Domain.Interfaces;

public interface IUserConfirmationService
{
    public Task<ConfirmationCode> GenerateConfirmationCodeAsync(string userId);
    public Task<bool> ValidateConfirmationCodeAsync(ConfirmationCode code);
}
