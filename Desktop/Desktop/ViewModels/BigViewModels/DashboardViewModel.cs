using GalaSoft.MvvmLight;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using Desktop.Models.PresentationModels;

namespace Desktop.ViewModels.BigViewModels;

public class DashboardViewModel : ViewModelBase
{
    public ObservableCollection<PieSeries<double>> PieChart { get; set; } = new();
    public ObservableCollection<Axis> XAxes { get; set; }
    public ObservableCollection<ISeries> Series { get; set; }
    public DashboardViewModel()
    {

        PieChart
        = new()
        {
                new PieSeries<double> { Values = new double[] { 1 }},
                new PieSeries<double> { Values = new double[] { 2 }},
                new PieSeries<double> { Values = new double[] { 3 }},
                new PieSeries<double> { Values = new double[] { 4 }},
                new PieSeries<double> { Values = new double[] { 5 }}
        };
        var data = new ObservableCollection<FinancialData>
        {
            new(new DateTime(2021, 1, 1), 523, 500, 450, 400),
            new(new DateTime(2021, 1, 2), 500, 450, 425, 400),
            new(new DateTime(2021, 1, 3), 490, 425, 400, 380),
            new(new DateTime(2021, 1, 4), 420, 400, 420, 380),
            new(new DateTime(2021, 1, 5), 520, 420, 490, 400),
            new(new DateTime(2021, 1, 6), 580, 490, 560, 440),
            new(new DateTime(2021, 1, 7), 570, 560, 350, 340),
            new(new DateTime(2021, 1, 8), 380, 350, 380, 330),
            new(new DateTime(2021, 1, 9), 440, 380, 420, 350),
            new(new DateTime(2021, 1, 10), 490, 420, 460, 400),
            new(new DateTime(2021, 1, 11), 520, 460, 510, 460),
            new(new DateTime(2021, 1, 12), 580, 510, 560, 500),
            new(new DateTime(2021, 1, 13), 600, 560, 540, 510),
            new(new DateTime(2021, 1, 14), 580, 540, 520, 500),
            new(new DateTime(2021, 1, 15), 580, 520, 560, 520),
            new(new DateTime(2021, 1, 16), 590, 560, 580, 520),
            new(new DateTime(2021, 1, 17), 650, 580, 630, 550),
            new(new DateTime(2021, 1, 18), 680, 630, 650, 600),
            new(new DateTime(2021, 1, 19), 670, 650, 600, 570),
            new(new DateTime(2021, 1, 20), 640, 600, 610, 560),
            new(new DateTime(2021, 1, 21), 630, 610, 630, 590)
        };

        Series = new()
        {
            new CandlesticksSeries<FinancialPointI>
            {
                UpFill = new SolidColorPaint(SKColor.Parse("#76EACB")),
                UpStroke = new SolidColorPaint(SKColor.Parse("#76EACB")) { StrokeThickness = 3},
                DownFill = new SolidColorPaint(SKColor.Parse("#F11C75")),
                DownStroke = new SolidColorPaint(SKColor.Parse("#F11C75")) { StrokeThickness = 3 },
                Values = data
                    .Select(x => new FinancialPointI(x.High, x.Open, x.Close, x.Low))
                    .ToArray()
            }
        };

        XAxes = new()
        {
            new Axis
            {                
                Labels = data
                    .Select(x => x.Date.ToString("dd MM yyyy"))
                    .ToArray()
            }
        };
    }


}
   
