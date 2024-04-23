using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Classes;

public class RegistrationService : IRegistrationService
{
    private readonly ITradeClient _tradeClient;

    public RegistrationService(ITradeClient clientAPI)
    {
        _tradeClient = clientAPI;
    }

    public async Task<DataResponse<RegistrationResponse>> Registration(User user)
    {
        return await _tradeClient.Post<RegistrationResponse>("/user/register", user); 
    }
}

