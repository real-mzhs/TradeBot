using UserService.Infrastructure.Context.Entities;
using UserService.Infrastructure.Entities;

namespace UserService.Infrastructure.Interfaces;

public interface IConfirmationCodeRepository
{
    public Task<ConfirmationCode?> GetByIdAsync(int id);
    public Task<ConfirmationCode?> GetByCodeAsync(string code);
    public Task<ConfirmationCode> InsertAsync(ConfirmationCode entity);
    void Update(ConfirmationCode entity);
    void Delete(ConfirmationCode entity);
    public Task<int> SaveChangesAsync(); 
}
