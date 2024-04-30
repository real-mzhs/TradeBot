using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using Desktop.Services.Network.API;
using RestSharp;
using Desktop.Models;

namespace Desktop.Services.Classes;

public class TradeService : ITradeService
{
    ITradeClient _tradeClient { get; set; }
    public TradeService()
    {
        _tradeClient = new TradeClient("https://api.binance.com");
    }
    public async Task<DataResponse<PositionResponse>> GetPositionsAsync(User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };
        return await _tradeClient.Get<PositionResponse>("/Position");
    }
    public async Task<DataResponse<PositionResponse>> CreatePositionAsync(Position Position)
    {
        return await _tradeClient.Post<PositionResponse>("/Position", Position);
    }
    public async Task<DataResponse<PositionResponse>> UpdatePositionAsync(Position Position)
    {
        return await _tradeClient.Put<PositionResponse>("/Position", Position);
    }
}
