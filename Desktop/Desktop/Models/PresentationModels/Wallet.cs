using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models.PresentationModels;

class Wallet
{
    public decimal balance { get; private set; }
    private ObservableCollection<Transaction> transactions;
    public decimal Balance
    {
        get => Math.Round(balance, 2);
        private set => balance = value;
    }

    public Wallet(decimal initialBalance)
    {
        Balance = initialBalance;
        transactions = new ObservableCollection<Transaction>();
    }
    public ObservableCollection<Transaction> GetTransactionHistory()
    {
        return transactions;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        Balance += amount;
        var transaction = new Transaction { Amount = amount, Date = DateTime.Now };
        transactions.Add(transaction);
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        Balance -= amount;
        var transaction = new Transaction { Amount = -amount, Date = DateTime.Now };
        transactions.Add(transaction);
    }
}
