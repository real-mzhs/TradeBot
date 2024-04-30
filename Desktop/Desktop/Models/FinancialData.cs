namespace Desktop.Models;

public class FinancialData
{
    public DateTime[] Dates { get; set; }
    public int[] Amounts { get; set; }
    public FinancialData(/*DateTime[] dates, int[] amounts*/)
    {
        //Dates = dates;
        //Amounts = amounts;
        Dates =
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
        ];

        Amounts = [1, 2, 3, 2, 4, 6, 20, 15, 17, 18, 25, 25, 26, 29, 35, 20, 27, 29, 40, 45, 45, 35, 30, 35, 40, 45, 48, 49, 50, 55];
    }

}
