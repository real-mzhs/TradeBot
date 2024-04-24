namespace Desktop.Models.PresentationModels;

public class FinancialData
{
    public FinancialData(DateTime[] dates, double[] amounts)
    {
        Dates = dates;
        Amounts = amounts;
    }

    public DateTime[] Dates { get; set; }
    public double[] Amounts { get; set; }
}
