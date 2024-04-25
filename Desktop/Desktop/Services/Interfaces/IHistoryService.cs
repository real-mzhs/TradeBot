using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IHistoryService
{
    public Task<DataResponse<HistoryResponse>> GetTradesHistory(User user);
    public Task<DataResponse<FinancialResponse>> GetFinancialHistory(User user);

}
