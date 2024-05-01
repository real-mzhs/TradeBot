using Desktop.Models;
using Desktop.Responses;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;

namespace Desktop.Services.Classes;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITradeClient _tradeClient;
    public AuthenticationService()
    {
        _tradeClient = new TradeClient("https://api.binance.com");
    }
    public async Task<DataResponse<AuthResponse>> AuthenticationAsync (User user)
    {
        var parameter = Parameter.CreateParameter("User", user, ParameterType.RequestBody);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<AuthResponse>("/auth/login", parameters); 
        
    }

}
