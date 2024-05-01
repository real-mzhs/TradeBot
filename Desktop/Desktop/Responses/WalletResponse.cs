using System.Collections.ObjectModel;
using Desktop.Models;

namespace Desktop.Responses;

public class WalletResponse
{
    public decimal balance { get; set; }
    public ObservableCollection<Transaction> transactions;
}
