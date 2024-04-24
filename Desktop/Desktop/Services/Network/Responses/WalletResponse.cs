using Desktop.Models.PresentationModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.Responses;

public class WalletResponse
{
    public decimal balance { get; set; }
    public ObservableCollection<Transaction> transactions;
}
