using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using Desktop.Services.Network;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class HistoryService : IHistoryService
{
    ITradeClient _clientAPI { get; set; }

    public HistoryService(ITradeClient clientAPI)
    {
        _clientAPI = clientAPI;
    }

    public async Task<TradesHistory> TradesHistory (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id.ToString(), ParameterType.GetOrPost);
        var parameters = new Parameter[] { parameter };

        var userHistory = await _clientAPI.Get<TradesHistory>("/history", parameters);
        return userHistory;
    }

}
