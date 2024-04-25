using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;

namespace Desktop.Services.Classes;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITradeClient _tradeClient;
    public AuthenticationService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<AuthResponse>> Authentication (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<AuthResponse>("/auth/login", parameters); 
        
    }

}
