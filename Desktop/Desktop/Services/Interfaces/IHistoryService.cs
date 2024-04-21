using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IHistoryService
{
    public Task<DataResponse<HistoryResponse>> TradesHistory(User user);

}
