using GalaSoft.MvvmLight;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using Desktop.Models.PresentationModels;
using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using System.Xml.Linq;
using Desktop.Services.Interfaces;
using System.Windows;
using Desktop.Services.Network.Responses;
using Desktop.Models.MainModels;
using GalaSoft.MvvmLight.Messaging;
using Desktop.Messages.DataMessages;

namespace Desktop.ViewModels.BigViewModels;

public class DashboardViewModel : ViewModelBase
{
    private readonly IMarketService _marketService;
    private readonly IHistoryService _historyService;
    private readonly ITradeService _tradeService;
    private readonly IMessenger _messenger;
    private User User { get; set; }

    private ObservableCollection<Coin> _coinList;
    public ObservableCollection<Coin> CoinList
    {
        get => _coinList;
        set => Set(ref _coinList, value);
    }
    private DataResponse<CoinResponse> _coinResponse;


    public ObservableCollection<ISeries> Series { get; set; }
    private DataResponse<FinancialResponse> _financialResponse;
    public FinancialData FinancialData { get; set; } = new();

    private static readonly SKColor s_gray = new(30, 127, 176);
    private static readonly SKColor s_gray2 = new(30, 127, 176);
    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }



    public ObservableCollection<PieSeries<int>> PieChart { get; set; } = new();
    private DataResponse<PositionResponse> _positionResponse;

    private ObservableCollection<Position> _positionList;
    public ObservableCollection<Position> PositionList
    {
        get => _positionList;
        set => Set(ref _positionList, value);
    }


    public DashboardViewModel(IMarketService marketService, IHistoryService historyService, ITradeService tradeService, IMessenger messenger)
    {
        _marketService = marketService;
        _historyService = historyService;
        _tradeService = tradeService;
        _messenger = messenger;

        _messenger.Register<UserDataMessage>(this, message => User = message.Data);



        //try
        //{
        //    _positionResponse = _tradeService.GetPositions(user).GetAwaiter().GetResult();
        //    PositionList = (ObservableCollection<Position>)_positionResponse.Data.Positions;
        //}
        //catch (Exception ex)
        //{

        //    MessageBox.Show($"Status code - {_positionResponse.StatusCode}: {ex.Message}");
        //}

        //foreach (var position in PositionList)
        //{
        //    PieChart.Add
        //        (
        //         new PieSeries<int>
        //         {
        //             Values = new int[] { position.Quantity },
        //             MaxRadialColumnWidth = 60,
        //             DataLabelsSize = 20,
        //             ToolTipLabelFormatter = point => $"{position.Coin.Name}\n {position.Quantity}"
        //         });
        //}

        PieChart
       = new()
       {
           
           new PieSeries<int>
            {
                Values = new int[] { 2 },
                MaxRadialColumnWidth = 70,
                Fill = new SolidColorPaint(SKColor.Parse("#FF5733")),                
                ToolTipLabelFormatter = point => $"Описание"
            },
                new PieSeries<int> { Values = new int[] { 1 }, MaxRadialColumnWidth = 70 },
                new PieSeries<int> { Values = new int[] { 2 }, MaxRadialColumnWidth = 70 },
                new PieSeries<int> { Values = new int[] { 3 }, MaxRadialColumnWidth = 70 },
                new PieSeries<int> { Values = new int[] { 4 }, MaxRadialColumnWidth = 70 },
                new PieSeries<int> { Values = new int[] { 5 }, MaxRadialColumnWidth = 70 }
       };





        //try
        //{
        //    _financialResponse = _historyService.GetFinancialHistory(user).GetAwaiter().GetResult();
        //    FinancialData = _financialResponse.Data.FinancialData;
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Status code - {_financialResponse.StatusCode}: {ex.Message}");
        //}

        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<int>
            {
                Values = FinancialData.Amounts,
                Fill = null,
                GeometrySize = 0,
                LineSmoothness = 1,
                Stroke = new LinearGradientPaint(new[]{ new SKColor(37, 2, 94), new SKColor(246, 168, 247) }) { StrokeThickness = 3 },
                GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(37, 2, 94), new SKColor(246, 168, 247) }) { StrokeThickness = 3 },
            }
        };

        XAxes =
        [
            new Axis
            {
                Labels = FinancialData.Dates
                    .Select(x => x.Date.ToString("dd.MM.yyyy"))
                    .ToArray(),
                TextSize = 12,
                Padding = new Padding(0),
                LabelsPaint = new SolidColorPaint(s_gray)
            }
        ];

        YAxes =
        [
            new Axis
            {

                TextSize = 12,
                Padding = new Padding(0, 10, 10, 10),
                LabelsPaint = new SolidColorPaint(s_gray),
                SeparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray2,
                    StrokeThickness = 1,

                }
            }
        ];




        //try
        //{
        //    _coinResponse = _marketService.GetCoins().GetAwaiter().GetResult();
        //    CoinList = (ObservableCollection<Coin>)_coinResponse.Data.Coins;
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Status code - {_coinResponse.StatusCode}: {ex.Message}");
        //}

        CoinList = new ObservableCollection<Coin>()
        {
            new Coin
            {
                Id = "USDT",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\rusta\\OneDrive\\Рабочий стол\\Study\\TradeBot\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\rusta\\OneDrive\\Рабочий стол\\Study\\TradeBot\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\rusta\\OneDrive\\Рабочий стол\\Study\\TradeBot\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
            new Coin
            {
                Id = "ETH",
                Name = "ETHERIUM",
                Amount = 50,
                Margin = -2.5,
                ImagePath = "C:\\Users\\rusta\\OneDrive\\Рабочий стол\\Study\\TradeBot\\Desktop\\Desktop\\Images\\pngwing.com (1).png",
                Cost = 10,
                Quantity = 5
            },
        };

    }


}


