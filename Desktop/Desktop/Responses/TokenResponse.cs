using Desktop.Models;

namespace Desktop.Responses
{
    public class TokenResponse
    {
        public Token Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
