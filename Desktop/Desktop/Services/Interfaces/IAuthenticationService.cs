using Desktop.Models;
using Desktop.Responses;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IAuthenticationService
{
    public Task<DataResponse<AuthResponse>> AuthenticationAsync(User user);

}
