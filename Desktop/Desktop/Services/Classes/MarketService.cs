using Desktop.Services.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;

namespace Desktop.Services.Classes;

class MarketService : IMarketService
{
    ITradeClient _tradeClient { get; set; }
    public MarketService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<CoinsResponse>> GetCoins()
    {
        return await _tradeClient.Get<CoinsResponse>("/coins");
    }
}
