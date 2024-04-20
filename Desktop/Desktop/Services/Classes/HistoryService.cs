using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network;
using Desktop.Services.Network.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class HistoryService : IHistoryService
{
    ITradeClient _tradeClient { get; set; }

    public HistoryService(ITradeClient clientAPI)
    {
        _tradeClient = clientAPI;
    }

    public async Task<DataResponse<HistoryResponse>> TradesHistory (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.UrlSegment);
        var parameters = new Parameter[] { parameter };

        var userHistory = await _tradeClient.Get<HistoryResponse>("/history", parameters); //GET https://myAPI.com/history?UserId={user.Id}
        return userHistory;
    }

}
