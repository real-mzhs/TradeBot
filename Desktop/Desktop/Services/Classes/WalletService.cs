using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using Desktop.Services.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Models.MainModels;
using Desktop.Models.PresentationModels;
using RestSharp;




namespace Desktop.Services.Classes;

class WalletService : IWalletService
{
    private ITradeClient _tradeClient { get; set; }
    
    public WalletService(ITradeClient tradeClient)
    {
         _tradeClient = tradeClient;
    }
    public async Task<DataResponse<WalletResponse>> GetWalletData(User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<WalletResponse>("/wallet", parameters);
    }

    public async Task<DataResponse<WalletResponse>> update(Wallet wallet)
    {
        return await _tradeClient.Put<WalletResponse>("/wallet", wallet);
    }
}
