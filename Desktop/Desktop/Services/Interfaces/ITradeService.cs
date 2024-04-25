using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface ITradeService
{
    public Task<DataResponse<PositionResponse>> UpdatePosition(Position Position);

    public Task<DataResponse<PositionResponse>> CreatePosition(Position Position);
    public Task<DataResponse<PositionResponse>> GetPositions(User user);


}
