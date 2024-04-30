using System.Collections.ObjectModel;

namespace Desktop.Models;

public class Wallet
{
    public string UserId { get; set; }
    public int Balance { get; set; }
    public ObservableCollection<Transaction> Transactions { get; set; }
    public Wallet()
    {
        Transactions = new ObservableCollection<Transaction>();
        Balance = 0;
    }
    public Wallet(string userId, ObservableCollection<Transaction> transactions, int balance)
    {
        UserId = userId;
        Transactions = transactions;
        Balance = balance;
    }
    public void Deposit(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        Balance += amount;
        var transaction = new Transaction { Amount = amount, Date = DateTime.Now };
        Transactions.Add(transaction);
    }

    public void Withdraw(int amount)
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
        Transactions.Add(transaction);
    }
    public ObservableCollection<Transaction> GetTransactionHistory()
    {
        return Transactions;
    }
}
