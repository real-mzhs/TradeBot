using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;
using Desktop.Services.Classes;

namespace Desktop.Services.Interfaces;

public interface IWalletService
{
    public Task<DataResponse<WalletResponse>> UpdateWalletAsync(Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletDataAsync(User user);

}
