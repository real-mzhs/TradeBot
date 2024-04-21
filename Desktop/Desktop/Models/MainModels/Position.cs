using Desktop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models.MainModels;

public class Position
{
    public string CoinId { get; set; }
    public int Quantity { get; set; }

    public int EntryPrice { get; set; }
    public int ExitPrice { get; set; }

    public PositionType Type { get; set; }

    public PositionStatus Status { get; set; }

}
