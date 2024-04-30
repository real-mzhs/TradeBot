using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

public class MarketResponse
{
    public IEnumerable<KlineData> KlineDatas { get; set; }

}
