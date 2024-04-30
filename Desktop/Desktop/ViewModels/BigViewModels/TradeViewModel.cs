using GalaSoft.MvvmLight;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore;
using Desktop.Models;
using System.Windows;
using Desktop.Services.Network.API;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desktop.ViewModels.BigViewModels;

public class TradeViewModel : ViewModelBase
{
    public ObservableCollection<FinancialPoint> _financialPoints;
    public ObservableCollection<FinancialPoint> FinancialPoints
    {
        get => _financialPoints;
        set => Set(ref _financialPoints, value);
    }
    public ObservableCollection<KlineData> _klineDatas;
    public ObservableCollection<KlineData> KlineDatas
    {
        get => _klineDatas;
        set => Set(ref _klineDatas, value);
    }
    private readonly IMarketService _marketService;
    private ObservableCollection<Coin> _coinList;
    public ObservableCollection<Coin> CoinList
    {
        get => _coinList;
        set => Set(ref _coinList, value);
    }
    MarketResponse _marketResponse { get; set; }
    public string ListenSymbol { get; set; }
    public string Interval { get; set; }
    public Axis[] XAxes { get; set; }

    public ISeries[] Series { get; set; }
    public ISeries[] PieSeries { get; set; }

    public TradeViewModel(IMarketService marketService)
    {
        _marketService = marketService;
        FinancialPoints = new();

        var binanceStringListener = new BinanceListener<StreamKlineEventData>();
        binanceStringListener.DataReceived += (sender, data) =>
        {
            FinancialPoints.Add(new FinancialPoint()
            {
                Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(data.k.T),
                High = (double)data.k.h,
                Open = (double)data.k.o,
                Close = (double)data.k.c,
                Low = (double)data.k.l
            });
        };

        binanceStringListener.StartListening($"btcusdt@kline_1m");
        
        //binanceStringListener.StartListening($"{ListenSymbol}@kline_{Interval}").GetAwaiter().GetResult();




        //KlineDatas = _marketService.GetKlineDatasAsync("BTCUSDT", "1d", "30").GetAwaiter().GetResult();
        //FinancialPoints = new();

        //foreach (var item in KlineDatas)
        //{
        //    FinancialPoints.Add(new FinancialPoint()
        //    {
        //        Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(item.KlineCloseTime),
        //        High = (double)item.HighPrice,
        //        Open = (double)item.OpenPrice,
        //        Close = (double)item.ClosePrice,
        //        Low = (double)item.LowPrice
        //    });
        //}





        Series = new ISeries[]
         {
            new CandlesticksSeries<FinancialPoint>
            {

                UpFill = new SolidColorPaint(SKColor.Parse("#76EACB")),
                UpStroke = new SolidColorPaint(SKColor.Parse("#76EACB")) { StrokeThickness = 3},
                DownFill = new SolidColorPaint(SKColor.Parse("#F11C75")),
                DownStroke = new SolidColorPaint(SKColor.Parse("#F11C75")) { StrokeThickness = 3 },
                Values = FinancialPoints
            }
         };



        CoinList = new ObservableCollection<Coin>()
        {
            new Coin
            {
                Id = "USDT",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\mziya\\Downloads\\TradeBot- (2)\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\mziya\\Downloads\\TradeBot- (2)\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\mziya\\Downloads\\TradeBot- (2)\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\mziya\\Downloads\\TradeBot- (2)\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
        };

        XAxes = new[]
       {

            new Axis
            {
                Labeler = value => new DateTime((long)value).ToString("dd.MM"),
                UnitWidth = TimeSpan.FromDays(0.5).Ticks
            }
        };

    }



}
