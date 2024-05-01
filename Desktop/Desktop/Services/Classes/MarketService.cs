using Desktop.Services.Network.Responses;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Models;
using RestSharp;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Globalization;
using Desktop.Responses;
using System.Diagnostics;

namespace Desktop.Services.Classes;

public class MarketService : IMarketService
{
    private readonly ITradeClient _binanceClient;
    public MarketService()
    {
        _binanceClient = new TradeClient("https://api.binance.com");        
    }

    private async Task<DataResponse<MarketResponse>> GetCoinHistoryAsync(string source, string symbol, string interval, string limit)
    {
        var parameter1 = Parameter.CreateParameter("symbol", symbol, ParameterType.QueryString);
        var parameter2 = Parameter.CreateParameter("interval", interval, ParameterType.QueryString);
        var parameter3 = Parameter.CreateParameter("limit", limit, ParameterType.QueryString);
        var parameters = new Parameter[] { parameter1, parameter2, parameter3 };

        return await _binanceClient.Get<MarketResponse>(source, parameters);

    }
    private async Task<DataResponse<MarketResponse>> PostOrderAsync(string source, string symbol, Enum side, Enum type, decimal price, decimal quantity)
    {
        var parameter1 = Parameter.CreateParameter("symbol", symbol, ParameterType.RequestBody);
        var parameter2 = Parameter.CreateParameter("side", side, ParameterType.RequestBody);
        var parameter3 = Parameter.CreateParameter("type", type, ParameterType.RequestBody);
        var parameter4 = Parameter.CreateParameter("quantity", quantity, ParameterType.RequestBody);
        var parameter5 = Parameter.CreateParameter("price", price, ParameterType.RequestBody);
        var parameters = new Parameter[] { parameter1, parameter2, parameter3, parameter4, parameter5 };

        return await _binanceClient.Post<MarketResponse>(source, parameters);
    }

    public async Task<ObservableCollection<KlineData>> GetKlineDatasAsync(string symbol, string interval, string limit)
    {
        var klineCollection = new ObservableCollection<KlineData>();

        var response = await GetCoinHistoryAsync("/api/v3/klines", symbol, interval, limit);

        try
        {
            var candles = JsonConvert.DeserializeObject<List<object[]>>(response.Content);

            foreach (var candle in candles)
            {
                KlineData klineData = new KlineData
                {
                    KlineOpenTime = long.Parse(candle[0].ToString(), CultureInfo.InvariantCulture),
                    OpenPrice = decimal.Parse(candle[1].ToString(), CultureInfo.InvariantCulture),
                    HighPrice = decimal.Parse(candle[2].ToString(), CultureInfo.InvariantCulture),
                    LowPrice = decimal.Parse(candle[3].ToString(), CultureInfo.InvariantCulture),
                    ClosePrice = decimal.Parse(candle[4].ToString(), CultureInfo.InvariantCulture),
                    Volume = decimal.Parse(candle[5].ToString(), CultureInfo.InvariantCulture),
                    KlineCloseTime = long.Parse(candle[6].ToString(), CultureInfo.InvariantCulture),
                    QuoteAssetVolume = decimal.Parse(candle[7].ToString(), CultureInfo.InvariantCulture),
                    NumberOfTrades = int.Parse(candle[8].ToString(), CultureInfo.InvariantCulture),
                    TakerBuyBaseAssetVolume = decimal.Parse(candle[9].ToString(), CultureInfo.InvariantCulture),
                    TakerBuyQuoteAssetVolume = decimal.Parse(candle[10].ToString(), CultureInfo.InvariantCulture)
                };
                klineCollection.Add(klineData);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        return klineCollection;
    }

    public async Task<ObservableCollection<PriceChangeData>> GetPriceChangeAsync(string symbol, string interval, string limit)
    {
        var PriceChangeDataCollection = new ObservableCollection<PriceChangeData>();

        var response = await GetCoinHistoryAsync("/api/v3/klines", symbol, interval, limit);

        try
        {
            var candles = JsonConvert.DeserializeObject<List<object[]>>(response.Content);

            foreach (var candle in candles)
            {
                PriceChangeData priceChangeData = new PriceChangeData
                {
                    Symbol = candle[0].ToString(),
                    PriceChange = candle[1].ToString(),
                    PriceChangePercent = candle[2].ToString(),
                    WeightedAvgPrice = candle[3].ToString(),
                    PrevClosePrice = candle[4].ToString(),
                    LastPrice = candle[5].ToString(),
                    LastQty = candle[6].ToString(),
                    BidPrice = candle[7].ToString(),
                    BidQty = candle[8].ToString(),
                    AskPrice = candle[9].ToString(),
                    AskQty = candle[10].ToString(),
                    OpenPrice = candle[11].ToString(),
                    HighPrice = candle[12].ToString(),
                    LowPrice = candle[13].ToString(),
                    Volume = candle[14].ToString(),
                    QuoteVolume = candle[15].ToString(),
                    OpenTime = long.Parse(candle[16].ToString(), CultureInfo.InvariantCulture),
                    CloseTime = long.Parse(candle[17].ToString(), CultureInfo.InvariantCulture),
                    FirstId = long.Parse(candle[18].ToString(), CultureInfo.InvariantCulture),
                    LastId = long.Parse(candle[19].ToString(), CultureInfo.InvariantCulture),
                    Count = int.Parse(candle[20].ToString(), CultureInfo.InvariantCulture),
                };
                PriceChangeDataCollection.Add(priceChangeData);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        return PriceChangeDataCollection;
    }

}
