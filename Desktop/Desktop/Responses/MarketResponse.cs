using Desktop.Models;

namespace Desktop.Responses;

public class MarketResponse
{
    public IEnumerable<KlineData> KlineDatas { get; set; }

}
