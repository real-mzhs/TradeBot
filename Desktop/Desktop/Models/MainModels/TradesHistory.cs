using Desktop.Enums;
using Desktop.Models.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models.MainModels;

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
