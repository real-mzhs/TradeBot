using Desktop.Services.Network.Responses;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.Models;
using RestSharp;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Globalization;

namespace Desktop.Services.Classes;

public class MarketService : IMarketService
{
    private readonly ITradeClient _binanceClient;
    public MarketService()
    {
        _binanceClient = new TradeClient("https://api.binance.com");        
    }

    private async Task<DataResponse<MarketResponse>> GetCoinHistoryAsync(string symbol, string interval, string limit)
    {
        var parameter1 = Parameter.CreateParameter("symbol", symbol, ParameterType.QueryString);
        var parameter2 = Parameter.CreateParameter("interval", interval, ParameterType.QueryString);
        var parameter3 = Parameter.CreateParameter("limit", limit, ParameterType.QueryString);
        var parameters = new Parameter[] { parameter1, parameter2, parameter3 };

        return await _binanceClient.Get<MarketResponse>("/api/v3/klines", parameters);

    }

    public async Task<ObservableCollection<KlineData>> GetKlineDatasAsync(string symbol, string interval, string limit)
    {
        var klineCollection = new ObservableCollection<KlineData>();

        var response = await GetCoinHistoryAsync(symbol, interval, limit);

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
    //public async Task<ObservableCollection<PriceChangeData>> GetPriceChangeAsync(string symbol, string interval, string limit)
    //{
    //    var PriceChangeDataCollection = new ObservableCollection<PriceChangeData>();

    //    var response = await GetCoinHistoryAsync(symbol, interval, limit);

    //    try
    //    {
    //        var candles = JsonConvert.DeserializeObject<List<object[]>>(response.Content);

    //        foreach (var candle in candles)
    //        {
    //            PriceChangeData priceChangeData = new PriceChangeData
    //            {
    //                KlineOpenTime = long.Parse(candle[0].ToString(), CultureInfo.InvariantCulture),
    //                OpenPrice = decimal.Parse(candle[1].ToString(), CultureInfo.InvariantCulture),
    //                HighPrice = decimal.Parse(candle[2].ToString(), CultureInfo.InvariantCulture),
    //                LowPrice = decimal.Parse(candle[3].ToString(), CultureInfo.InvariantCulture),
    //                ClosePrice = decimal.Parse(candle[4].ToString(), CultureInfo.InvariantCulture),
    //                Volume = decimal.Parse(candle[5].ToString(), CultureInfo.InvariantCulture),
    //                KlineCloseTime = long.Parse(candle[6].ToString(), CultureInfo.InvariantCulture),
    //                QuoteAssetVolume = decimal.Parse(candle[7].ToString(), CultureInfo.InvariantCulture),
    //                NumberOfTrades = int.Parse(candle[8].ToString(), CultureInfo.InvariantCulture),
    //                TakerBuyBaseAssetVolume = decimal.Parse(candle[9].ToString(), CultureInfo.InvariantCulture),
    //                TakerBuyQuoteAssetVolume = decimal.Parse(candle[10].ToString(), CultureInfo.InvariantCulture)
    //            };
    //            PriceChangeDataCollection.Add(priceChangeData);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Ошибка: " + ex.Message);
    //    }
    //    return PriceChangeDataCollection;
    //}

}
