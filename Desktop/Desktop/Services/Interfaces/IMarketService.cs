using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IMarketService
{
    public Task<DataResponse<CoinResponse>> GetCoinsAsync();

}
