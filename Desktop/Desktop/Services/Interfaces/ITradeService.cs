using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface ITradeService
{
    public Task<DataResponse<PositionResponse>> CreatePosition(Position openPosition);
    public Task<DataResponse<PositionResponse>> GetOpenPositions();

}
