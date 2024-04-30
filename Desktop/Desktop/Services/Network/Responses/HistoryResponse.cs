using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

public class HistoryResponse
{
    public IEnumerable<TradesHistory> History { get; set; }
}
