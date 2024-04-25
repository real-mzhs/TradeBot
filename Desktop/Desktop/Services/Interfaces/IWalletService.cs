using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;
using Desktop.Services.Classes;

namespace Desktop.Services.Interfaces;

public interface IWalletService
{
    public Task<DataResponse<WalletResponse>> Update(Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletData(User user);

}
