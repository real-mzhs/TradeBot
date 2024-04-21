using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface ITradeService
{
    public Task<DataResponse<PositionResponse>> CreatePosition(Position openPosition);
    public Task<DataResponse<PositionResponse>> GetOpenPositions();

}
