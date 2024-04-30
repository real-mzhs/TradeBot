using Desktop.Models;
using Desktop.Services.Network.Responses;
using System.Collections.ObjectModel;

namespace Desktop.Services.Interfaces;

public interface IMarketService
{
    public Task<ObservableCollection<KlineData>> GetKlineDatasAsync(string symbol, string interval, string limit);


}
