using Desktop.Models;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IWalletService
{
    public Task<DataResponse<WalletResponse>> UpdateWalletAsync(Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletDataAsync(User user);

}
