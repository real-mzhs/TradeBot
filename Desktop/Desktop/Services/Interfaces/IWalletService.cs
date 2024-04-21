using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IWalletService
{
    public Task<DataResponse<WalletResponse>> update(Wallet wallet);
    public Task<DataResponse<WalletResponse>> GetWalletData(User user);

}
