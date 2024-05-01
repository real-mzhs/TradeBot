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
using LiveChartsCore.Drawing;
using Prism.Commands;

namespace Desktop.ViewModels.BigViewModels;

public class TradeViewModel : ViewModelBase
{
    public ObservableCollection<KlineData> KlineDatas { get; set; }
    private readonly IMarketService _marketService;
    public string Symbol { get; set; } = "BTCUSDT";
    public string Interval { get; set; } = "1h";
    public string limit { get; set; } = "24";
    public Axis[] XAxes { get; set; }

    public DelegateCommand BuyCommand {  get; set; }
    public ISeries[] Series { get; set; }
    public ISeries[] PieSeries { get; set; }

    private ObservableCollection<FinancialPoint> _financialPoints;

    public ObservableCollection<FinancialPoint> FinancialPoints
    {
        get => _financialPoints;
        set => Set(ref _financialPoints, value);
    }

    private ObservableCollection<Coin> _coinList;

    public ObservableCollection<Coin> CoinList
    {
        get => _coinList;
        set => Set(ref _coinList, value);
    }


    public TradeViewModel(IMarketService marketService)
    {
        _marketService = marketService;
        FinancialPoints = new();


        Series = new ISeries[]
        {
            new CandlesticksSeries<FinancialPoint>
            {
                UpFill = new SolidColorPaint(SKColor.Parse("#76EACB")),
                UpStroke = new SolidColorPaint(SKColor.Parse("#76EACB")) { StrokeThickness = 3 },
                DownFill = new SolidColorPaint(SKColor.Parse("#F11C75")),
                DownStroke = new SolidColorPaint(SKColor.Parse("#F11C75")) { StrokeThickness = 3 },
                Values = FinancialPoints
            }
        };


        long hoursSpan = TimeSpan.FromHours(0.5).Ticks;
        long minutesSpan = TimeSpan.FromMinutes(0.5).Ticks;
        long daysSpan = TimeSpan.FromDays(0.5).Ticks;

        XAxes = new[]
        {
            new Axis
            {
                Labeler = value => new DateTime((long)value).ToString("HH:mm"),
                UnitWidth = hoursSpan
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
            }
        };



        ChartInitializeAsync();
    } //ctor

    private async void ChartInitializeAsync()
    {
        KlineDatas = await _marketService.GetKlineDatasAsync(Symbol, Interval, limit);
        foreach (var item in KlineDatas)
        {
            FinancialPoints.Add(new FinancialPoint()
            {
                Date = DateTime.UnixEpoch.AddMilliseconds(item.KlineCloseTime),
                High = (double)item.HighPrice,
                Open = (double)item.OpenPrice,
                Close = (double)item.ClosePrice,
                Low = (double)item.LowPrice
            });
        }

        //var binanceStringListener = new BinanceListener<StreamKlineEventData>();
        //binanceStringListener.DataReceived += (sender, data) =>
        //{
        //    if (FinancialPoints.Last().Date.Minute <= DateTime.UnixEpoch.AddMilliseconds(data.k.T).Minute)
        //    {
        //        FinancialPoints.Add(new FinancialPoint()
        //        {
        //            Date = DateTime.UnixEpoch.AddMilliseconds(data.k.T),
        //            High = (double)data.k.h,
        //            Open = (double)data.k.o,
        //            Close = (double)data.k.c,
        //            Low = (double)data.k.l
        //        });
        //    }
        //};
        //await binanceStringListener.StartListening($"btcusdt@kline_1m");
        //await binanceStringListener.StartListening($"{ListenSymbol}@kline_{Interval}").GetAwaiter().GetResult();
    }
}