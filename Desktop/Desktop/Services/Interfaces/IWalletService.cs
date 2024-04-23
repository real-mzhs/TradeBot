using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IWalletService
{
    public Task<DataResponse<WalletResponse>> update(Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletData(User user);

}
