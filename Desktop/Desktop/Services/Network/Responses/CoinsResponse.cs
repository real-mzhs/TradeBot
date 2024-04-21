using Desktop.Models.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

class CoinsResponse
{
    public IEnumerable<Coin> Coins { get; set; }
}
