using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using Desktop.Models.MainModels;
using RestSharp;
using Desktop.Services.Network.API;

namespace Desktop.Services.Classes;

public class WalletService : IWalletService
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
