using Desktop.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

class HistoryResponse
{
    public IEnumerable<TradesHistory> History { get; set; }
}
