using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class RegistrationService : IRegistrationService
{
    private readonly ITradeClient _tradeClient;

    public RegistrationService(ITradeClient clientAPI)
    {
        _tradeClient = clientAPI;
    }

    public async Task<DataResponse<RegistrationResponse>> Registration(User user)
    {

        return await _tradeClient.Post<RegistrationResponse>("/registration", user); 

    }
}

