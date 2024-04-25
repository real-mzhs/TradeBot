using UserService.Domain.Interfaces;
using UserService.Infrastructure.Entities;
using UserService.Infrastructure.Interfaces;

namespace UserService.Domain.Services;

public class UserConfirmationService(IConfirmationCodeRepository repository) : IUserConfirmationService
{
    public async Task<ConfirmationCode> GenerateConfirmationCodeAsync(string userId)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var code = new char[6];

        for (var i = 0; i < 6; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }

        var confirmationCode = new ConfirmationCode { UserId = userId, Code = new string(code), };
        await repository.InsertAsync(confirmationCode);
        
        return confirmationCode;
    }

    public async Task<bool> ValidateConfirmationCodeAsync(ConfirmationCode code)
    {
        var codeEntity = await repository.GetByCodeAsync(code.Code);
        ArgumentNullException.ThrowIfNull(codeEntity);

        return codeEntity.UserId == code.UserId;
    }
}
