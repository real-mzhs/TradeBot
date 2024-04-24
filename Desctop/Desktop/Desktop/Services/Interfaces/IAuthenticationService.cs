using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IAuthenticationService
{
    public Task<DataResponse<AuthResponse>> Authentication(User user);

}
