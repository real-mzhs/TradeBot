using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models;
public class KlineData
{
    public long KlineOpenTime { get; set; } // Время начала свечи
    public decimal OpenPrice { get; set; } // Цена открытия
    public decimal HighPrice { get; set; } // Наивысшая цена
    public decimal LowPrice { get; set; } // Низшая цена
    public decimal ClosePrice { get; set; } // Цена закрытия
    public decimal Volume { get; set; } // Объем
    public long KlineCloseTime { get; set; } // Время закрытия свечи
    public decimal QuoteAssetVolume { get; set; } // Объем котируемого актива
    public int NumberOfTrades { get; set; } // Количество сделок
    public decimal TakerBuyBaseAssetVolume { get; set; } // Объем актива, купленного по цене спроса (тейкера)
    public decimal TakerBuyQuoteAssetVolume { get; set; } // Объем котируемого актива, купленного по цене спроса (тейкера)
}
