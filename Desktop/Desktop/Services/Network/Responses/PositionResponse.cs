using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

public class PositionResponse
{
    public IEnumerable<Position> Positions { get; set; }
}
