using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using Desktop.Services.Network;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class TradeService : ITradeService
{
    ITradeClient _tradeClient { get; set; }
    public TradeService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<CoinsResponse>> GetCoins()
    {
        return await _tradeClient.Get<CoinsResponse>("/coins");
    }
    public async Task<DataResponse<OpenPositionResponse>> GetOpenPositions()
    {
        return await _tradeClient.Get<OpenPositionResponse>("/coins");
    }
}
