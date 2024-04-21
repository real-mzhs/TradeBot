using Desktop.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

class PositionResponse
{
    public IEnumerable<Position> Positions { get; set; }
}
