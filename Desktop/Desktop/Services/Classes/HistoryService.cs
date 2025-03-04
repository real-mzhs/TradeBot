﻿using Desktop.Models;
using Desktop.Responses;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Services.Network.Responses;
using RestSharp;


namespace Desktop.Services.Classes;

public class HistoryService : IHistoryService
{
    ITradeClient _tradeClient { get; set; }

    public HistoryService()
    {
        _tradeClient = new TradeClient("https://api.binance.com");
    }

    public async Task<DataResponse<HistoryResponse>> GetTradesHistoryAsync (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id, ParameterType.QueryString);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<HistoryResponse>("/history", parameters);
        
    } 
    public async Task<DataResponse<FinancialResponse>> GetFinancialHistoryAsync (User user)
    {
        var parameter = Parameter.CreateParameter("UserId", user.Id, ParameterType.QueryString);
        var parameters = new Parameter[] { parameter };

        return await _tradeClient.Get<FinancialResponse>("/history/financial", parameters); 
        
    }

}
