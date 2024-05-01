using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using RestSharp;
using Desktop.Services.Network.API;
using Desktop.Models;
using Desktop.Responses;

namespace Desktop.Services.Classes;

public class WalletService : IWalletService
{
    private ITradeClient _tradeClient { get; set; }
    
    public WalletService()
    {
         _tradeClient = new TradeClient("https://api.binance.com");
    }
    public async Task<DataResponse<WalletResponse>> GetWalletDataAsync(User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<WalletResponse>("/wallet", parameters);
    }

    public async Task<DataResponse<WalletResponse>> UpdateWalletAsync(Models.Wallet wallet)
    {
        return await _tradeClient.Put<WalletResponse>("/wallet", wallet);
    }
    public async Task<DataResponse<WalletResponse>> CreateWalletAsync(Models.Wallet wallet)
    {
        return await _tradeClient.Post<WalletResponse>("/wallet", wallet);
    }
}
