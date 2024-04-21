using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Services.Network.API;

namespace Desktop.Services.Classes;

class TradeService : ITradeService
{
    ITradeClient _tradeClient { get; set; }
    public TradeService(ITradeClient tradeClient)
    {
        _tradeClient = tradeClient;
    }
    public async Task<DataResponse<PositionResponse>> GetOpenPositions()
    {
        return await _tradeClient.Get<PositionResponse>("/openPosition");
    }

    public async Task<DataResponse<PositionResponse>> CreatePosition(Position openPosition)
    {
        return await _tradeClient.Post<PositionResponse>("/openPosition", openPosition);
    }
}
