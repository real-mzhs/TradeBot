using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;

namespace Desktop.Services.Classes;

public class RegistrationService : IRegistrationService
{
    private readonly ITradeClient _tradeClient;

    public RegistrationService(ITradeClient clientAPI)
    {
        _tradeClient = clientAPI;
    }

    public async Task<DataResponse<RegistrationResponse>> RegistrationAsync(User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };
        return await _tradeClient.Post<RegistrationResponse>("/user/register", parameters); 
    }
}

