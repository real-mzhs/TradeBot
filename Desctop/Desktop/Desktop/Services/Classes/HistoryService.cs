using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;


namespace Desktop.Services.Classes;

public class HistoryService : IHistoryService
{
    ITradeClient _tradeClient { get; set; }

    public HistoryService(ITradeClient clientAPI)
    {
        _tradeClient = clientAPI;
    }

    public async Task<DataResponse<HistoryResponse>> TradesHistory (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.QueryString);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<HistoryResponse>("/history", parameters); //GET https://myAPI.com/history?UserId={user.Id}
        
    }

}
