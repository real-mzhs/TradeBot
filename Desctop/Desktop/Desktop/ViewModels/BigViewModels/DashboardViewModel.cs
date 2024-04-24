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

namespace Desktop.ViewModels.BigViewModels;

public class DashboardViewModel : ViewModelBase
{
    public ObservableCollection<PieSeries<int>> PieChart { get; set; } = new();
    public ObservableCollection<ISeries> Series { get; set; }

    private static readonly SKColor s_gray = new(195, 195, 195);
    private static readonly SKColor s_gray2 = new(61, 61, 61);
    public FinancialData FinancialData { get; set; } = new();

    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }

    private ObservableCollection<Coin> _coinList;
    public ObservableCollection<Coin> CoinList
    {
        get => _coinList;
        set => Set(ref _coinList, value);
    }
    private Coin _coinItem;
    public Coin CoinItem
    {
        get => _coinItem;
        set => Set(ref _coinItem, value);
    }
    public DashboardViewModel()
    {
        CoinList = new ObservableCollection<Coin>();

        CoinItem = new Coin { Id="ETH", Name="ETHERIUM", Amount=50, Margin=-2.5, ImagePath= "C:\\Users\\rusta\\OneDrive\\Рабочий стол\\rhgwtrh\\Desktop\\Desktop\\Images\\pngwing.com (1).png", Cost=10, Quantity=5 };
        CoinList.Add(CoinItem);
        CoinList.Add(CoinItem);
        CoinList.Add(CoinItem);
        CoinList.Add(CoinItem);
        CoinList.Add(CoinItem);
        CoinList.Add(CoinItem);

        PieChart
       = new()
       {
           new PieSeries<int>
            {
                Values = new int[] { 2 },
                MaxRadialColumnWidth = 60,
                Fill = new SolidColorPaint(SKColor.Parse("#FF5733")), // Установите желаемый цвет здесь
                DataLabelsSize = 20 // Размер шрифта подписей данных
            },
                new PieSeries<int> { Values = new int[] { 1 }, MaxRadialColumnWidth = 60 },
                new PieSeries<int> { Values = new int[] { 2 }, MaxRadialColumnWidth = 60 },
                new PieSeries<int> { Values = new int[] { 3 }, MaxRadialColumnWidth = 60 },
                new PieSeries<int> { Values = new int[] { 4 }, MaxRadialColumnWidth = 60 },
                new PieSeries<int> { Values = new int[] { 5 }, MaxRadialColumnWidth = 60 }
       };



        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<int>
            {
                Values = FinancialData.Amounts,
                Fill = null,
                GeometrySize = 0,
                LineSmoothness = 0.5,
            }
        };

        XAxes = new Axis[]
        {
            new Axis
            {
                Labels = FinancialData.Dates
                    .Select(x => x.Date.ToString("dd.MM.yyyy"))
                    .ToArray(),


                TextSize = 18,
                Padding = new Padding(5, 0, 5, 5),
                LabelsPaint = new SolidColorPaint(s_gray)


            }
        };

        YAxes = new Axis[]
        {
            new Axis
            {

                TextSize = 18,
                Padding = new Padding(5, 15, 15, 0),
                LabelsPaint = new SolidColorPaint(s_gray),
                SeparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray2,
                    StrokeThickness = 1,

                }
            }
        };

    }


}


