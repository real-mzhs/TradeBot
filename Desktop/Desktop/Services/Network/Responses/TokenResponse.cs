using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Models.MainModels;

namespace Desktop.Services.Network.Responses
{
    public class TokenResponse
    {
        public Token Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
