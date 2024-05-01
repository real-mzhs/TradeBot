using Desktop.Models;
using Desktop.Responses;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IWalletService
{
    public Task<DataResponse<WalletResponse>> UpdateWalletAsync(Models.Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletDataAsync(User user);

}
