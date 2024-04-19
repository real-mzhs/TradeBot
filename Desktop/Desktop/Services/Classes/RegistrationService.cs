using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class RegistrationService : IRegistrationService
{
    private readonly ITradeClient _clientAPI;

    public RegistrationService(ITradeClient clientAPI)
    {
        _clientAPI = clientAPI;
    }

    public async Task<DataResponse<RegistrationResponse>> Registration(User user)
    {

        return await _clientAPI.Post<RegistrationResponse>("/registration", user); 

    }
}

