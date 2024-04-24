using GalaSoft.MvvmLight;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using Desktop.Models.PresentationModels;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Painting.Effects;

namespace Desktop.ViewModels.BigViewModels;

public class DashboardViewModel : ViewModelBase
{
    public ObservableCollection<PieSeries<double>> PieChart { get; set; } = new();
    public ObservableCollection<ISeries> Series { get; set; }

    private static readonly SKColor s_gray = new(195, 195, 195);
    private static readonly SKColor s_gray1 = new(160, 160, 160);
    private static readonly SKColor s_gray2 = new(90, 90, 90);
    public FinancialData FinancialData { get; set; } = new FinancialData(
        [
            new DateTime(2021, 1, 1),
            new DateTime(2021, 1, 2),
            new DateTime(2021, 1, 3),
            new DateTime(2021, 1, 4),
            new DateTime(2021, 1, 5),
            new DateTime(2021, 1, 6),
            new DateTime(2021, 1, 7),
            new DateTime(2021, 1, 8),
            new DateTime(2021, 1, 9),
            new DateTime(2021, 1, 10),
            new DateTime(2021, 1, 11),
            new DateTime(2021, 1, 12),
            new DateTime(2021, 1, 13),
            new DateTime(2021, 1, 14),
            new DateTime(2021, 1, 15),
            new DateTime(2021, 1, 16),
            new DateTime(2021, 1, 17),
            new DateTime(2021, 1, 18),
            new DateTime(2021, 1, 19),
            new DateTime(2021, 1, 20),
            new DateTime(2021, 1, 21),
            new DateTime(2021, 1, 22),
            new DateTime(2021, 1, 23),
            new DateTime(2021, 1, 24),   
            new DateTime(2021, 1, 25),
            new DateTime(2021, 1, 26),
            new DateTime(2021, 1, 27),
            new DateTime(2021, 1, 28),
            new DateTime(2021, 1, 29),
            new DateTime(2021, 1, 30),

        ],
        [1, 2, 3, 2, 4, 6, 20, 15, 17, 18, 25, 25, 26, 29, 35, 20, 27, 29, 40, 45, 45, 35, 30, 35, 40, 45, 48, 49, 50, 55]);
    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }



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

        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<double>
            {
                Values = FinancialData.Amounts,
                Fill = null,
                GeometrySize = 0,
                LineSmoothness = 0,
            }
        };

        XAxes = new Axis[]
        {
            new Axis
            {
                Labels = FinancialData.Dates
                    .Select(x => x.Date.ToString("dd.MM.yyyy"))
                    .ToArray(),
                
                NamePaint = new SolidColorPaint(s_gray1),
                TextSize = 18,
                Padding = new Padding(5, 15, 5, 5),
                LabelsPaint = new SolidColorPaint(s_gray),
                SeparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1,
                    PathEffect = new DashEffect(new float[] { 3, 3 })
                },
                SubseparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray2,
                    StrokeThickness = 0.5f
                },
                SubseparatorsCount = 9,
                ZeroPaint = new SolidColorPaint
                {
                    Color = s_gray1,
                    StrokeThickness = 2
                },
                TicksPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1.5f
                },
                SubticksPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1
                }
            }
        };

        YAxes = new Axis[]
        {
            new Axis
            {                
                NamePaint = new SolidColorPaint(s_gray1),
                TextSize = 18,
                Padding = new Padding(5, 0, 15, 0),
                LabelsPaint = new SolidColorPaint(s_gray),
                SeparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1,
                    PathEffect = new DashEffect(new float[] { 3, 3 })
                },
                SubseparatorsPaint = new SolidColorPaint
                {
                    Color = s_gray2,
                    StrokeThickness = 0.5f
                },
                SubseparatorsCount = 9,
                ZeroPaint = new SolidColorPaint
                {
                    Color = s_gray1,
                    StrokeThickness = 2
                },
                TicksPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1.5f
                },
                SubticksPaint = new SolidColorPaint
                {
                    Color = s_gray,
                    StrokeThickness = 1
                }
            }
        };
    }


}


