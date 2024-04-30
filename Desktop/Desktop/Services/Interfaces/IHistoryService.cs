using Desktop.Models;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IHistoryService
{
    public Task<DataResponse<HistoryResponse>> GetTradesHistoryAsync(User user);
    public Task<DataResponse<FinancialResponse>> GetFinancialHistoryAsync(User user);

}
