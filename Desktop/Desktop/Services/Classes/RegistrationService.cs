using Desktop.Models;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;

namespace Desktop.Services.Classes;

public class RegistrationService : IRegistrationService
{
    private readonly ITradeClient _tradeClient;

    public RegistrationService()
    {
        _tradeClient = new TradeClient("https://api.binance.com");
    }

    public async Task<DataResponse<RegistrationResponse>> RegistrationAsync(User user)
    {
        var parameter = Parameter.CreateParameter("User", user, ParameterType.RequestBody);
        var parameters = new Parameter[] { parameter };
        return await _tradeClient.Post<RegistrationResponse>("/user/register", parameters); 
    }
}

