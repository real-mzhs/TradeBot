using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class HistoryService : IHistoryService
{
    IClientAPI _clientAPI { get; set; }

    public HistoryService(IClientAPI clientAPI)
    {
        _clientAPI = clientAPI;
    }

    public async Task<TradesHistory> TradesHistory (User user)
    {
        string resource = $"/users/{user.Id}/history";

        var userHistory = await _clientAPI.Get<TradesHistory>(resource);

        return userHistory;
    }

}
