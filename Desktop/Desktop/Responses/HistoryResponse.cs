using Desktop.Models;

namespace Desktop.Responses;

public class HistoryResponse
{
    public IEnumerable<TradesHistory> History { get; set; }
}
