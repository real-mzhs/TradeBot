using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network;
using Desktop.Services.Network.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class AuthenticationService : IAuthenticationService
{
    ITradeClient _tradeClient {  get; set; }
    public AuthenticationService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<AuthResponse>> Authentication (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<AuthResponse>("/auth", parameters); 
        
    }

}
