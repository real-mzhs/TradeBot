using Desktop.Enums;

namespace Desktop.Models;

public class TradesHistory
{
    public string Id { get; set; }
    public int Amount { get; set; }
    public Coin Coin { get; set; }
    public int EntryPrice { get; set; }
    public int ExitPrice { get; set; }
    public int Margin { get; set; }
    public int Quantity { get; set; }
    public PositionType Type { get; set; }
}
