using Desktop.Models;
using Desktop.Responses;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface ITradeService
{
    public Task<DataResponse<PositionResponse>> UpdatePositionAsync(Position Position);

    public Task<DataResponse<PositionResponse>> CreatePositionAsync(Position Position);
    public Task<DataResponse<PositionResponse>> GetPositionsAsync(User user);


}
