using Desktop.Models.PresentationModels;
using GalaSoft.MvvmLight;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore;
using Prism.Commands;
using LiveChartsCore.SkiaSharpView.Drawing.Segments;

namespace Desktop.ViewModels.BigViewModels;

public class TradeViewModel : ViewModelBase
{

    private ObservableCollection<Coin> _coinList;
    public ObservableCollection<Coin> CoinList
    {
        get => _coinList;
        set => Set(ref _coinList, value);
    }


    public DelegateCommand ActionCommand { get; set; }
    
    public Axis[] XAxes { get; set; }

    public ISeries[] Series { get; set; }
    public ISeries[] PieSeries { get; set; }



    public TradeViewModel()
    {

        Series = new ISeries[]
         {
            new CandlesticksSeries<FinancialPoint>
            {

                UpFill = new SolidColorPaint(SKColor.Parse("#76EACB")),
                UpStroke = new SolidColorPaint(SKColor.Parse("#76EACB")) { StrokeThickness = 3},
                DownFill = new SolidColorPaint(SKColor.Parse("#F11C75")),
                DownStroke = new SolidColorPaint(SKColor.Parse("#F11C75")) { StrokeThickness = 3 },
                Values = new ObservableCollection<FinancialPoint>
                {

                    new FinancialPoint(new DateTime(2021, 1, 1), 523, 500, 450, 400),
                    new FinancialPoint(new DateTime(2021, 1, 2), 500, 450, 425, 400),
                    new FinancialPoint(new DateTime(2021, 1, 3), 490, 425, 400, 380),
                    new FinancialPoint(new DateTime(2021, 1, 4), 420, 400, 420, 380),
                    new FinancialPoint(new DateTime(2021, 1, 5), 520, 420, 490, 400),
                    new FinancialPoint(new DateTime(2021, 1, 6), 580, 490, 560, 440),
                    new FinancialPoint(new DateTime(2021, 1, 7), 570, 560, 350, 340),
                    new FinancialPoint(new DateTime(2021, 1, 8), 380, 350, 380, 330),
                    new FinancialPoint(new DateTime(2021, 1, 9), 440, 380, 420, 350),
                    new FinancialPoint(new DateTime(2021, 1, 10), 490, 420, 460, 400),
                    new FinancialPoint(new DateTime(2021, 1, 11), 520, 460, 510, 460),
                    new FinancialPoint(new DateTime(2021, 1, 12), 580, 510, 560, 500),
                    new FinancialPoint(new DateTime(2021, 1, 13), 600, 560, 540, 510),
                    new FinancialPoint(new DateTime(2021, 1, 14), 580, 540, 520, 500),
                    new FinancialPoint(new DateTime(2021, 1, 15), 580, 520, 560, 520),
                    new FinancialPoint(new DateTime(2021, 1, 16), 590, 560, 580, 520),
                    new FinancialPoint(new DateTime(2021, 1, 17), 650, 580, 630, 550),
                    new FinancialPoint(new DateTime(2021, 1, 18), 680, 630, 650, 600),
                    new FinancialPoint(new DateTime(2021, 1, 19), 670, 650, 600, 570),
                    new FinancialPoint(new DateTime(2021, 1, 20), 640, 600, 610, 560),
                    new FinancialPoint(new DateTime(2021, 1, 21), 630, 610, 630, 590),
                    new FinancialPoint(new DateTime(2021, 1, 22), 650, 600, 630, 590),

                    new FinancialPoint(new DateTime(2021, 1, 23), 590, 500, 450, 400),
                    new FinancialPoint(new DateTime(2021, 1, 24), 500, 450, 425, 400),
                    new FinancialPoint(new DateTime(2021, 1, 25), 490, 425, 400, 380),
                    new FinancialPoint(new DateTime(2021, 1, 26), 420, 400, 420, 380),
                    new FinancialPoint(new DateTime(2021, 1, 27), 520, 420, 490, 400),
                    new FinancialPoint(new DateTime(2021, 1, 28), 580, 490, 560, 440),
                    new FinancialPoint(new DateTime(2021, 1, 29), 570, 560, 350, 340),
                    new FinancialPoint(new DateTime(2021, 1, 30), 380, 350, 380, 330),

                    new FinancialPoint(new DateTime(2021, 1, 31), 650, 600, 630, 590),
                    new FinancialPoint(new DateTime(2021, 2, 1), 690, 600, 650, 600),
                    new FinancialPoint(new DateTime(2021, 2, 2), 490, 600, 450, 700),
                    new FinancialPoint(new DateTime(2021, 2, 3),  350,300, 330, 490),
                    new FinancialPoint(new DateTime(2021, 2, 4), 590, 500, 550, 500),

                    new FinancialPoint(new DateTime(2021, 2, 5), 690, 600, 650, 600),
                    new FinancialPoint(new DateTime(2021, 2, 6), 690, 500, 750, 700),
                    new FinancialPoint(new DateTime(2021, 2, 7), 790, 700, 750, 600),
                    new FinancialPoint(new DateTime(2021, 2, 8), 890, 560, 699, 620),
                    new FinancialPoint(new DateTime(2021, 2, 9), 690, 600, 650, 700),
                    new FinancialPoint(new DateTime(2021, 2, 10), 790,870, 850, 800),
                },
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

                Labeler = value => new DateTime((long)value).ToString("MMM dd"),
                UnitWidth = TimeSpan.FromDays(0.5).Ticks
            }
        };



          ActionCommand = new DelegateCommand(
          () =>
          {
              
          });

    }



}
