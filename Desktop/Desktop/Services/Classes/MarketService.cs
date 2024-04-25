﻿using Desktop.Services.Network.Responses;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;

namespace Desktop.Services.Classes;

public class MarketService : IMarketService
{
    ITradeClient _tradeClient { get; set; }
    public MarketService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<CoinResponse>> GetCoinsAsync()
    {
        return await _tradeClient.Get<CoinResponse>("/coins");
    }
}
