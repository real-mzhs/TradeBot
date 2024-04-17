using Desktop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models.MainModels;

public class OpenPosition
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Amount { get; set; }
    public string StockId { get; set; } = Guid.NewGuid().ToString();

    public int EntryPrice { get; set; }

    public int Quantity { get; set; }

    public PositionType Type { get; set; }

    public PositionStatus Status { get; set; }

}
