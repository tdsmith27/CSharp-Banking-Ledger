using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        public string username { get; private set; }
        private string pin;
        List<Transaction> transactionLog;
        decimal balance;

        public Account(string username, string pin)
        {
            this.username = username;
            this.pin = pin;
            transactionLog = new List<Transaction>();
            balance = 0;
        }      

        public void Deposit(decimal amount)
        {
            var transaction = new Transaction("Deposit", amount, balance + amount);
            balance += amount;
            transactionLog.Add(transaction);
        }

        public void Withdraw (decimal amount)
        {
            if (amount > balance)
            {
                throw new Exception("Not enough funds");
            }
            var transaction = new Transaction("Withdrawal", amount, balance - amount);
            balance -= amount;
            transactionLog.Add(transaction);            
        }

        public string CheckBalance()
        {
            return balance.ToString("n2");
        }

        public void LogTransactions()
        {
            for (int i = 0; i < transactionLog.Count; i++)
            {
                var transaction = transactionLog[i];
                Console.WriteLine($"{i + 1} - {transaction.Log()}");                
            }
        }

        public void AuthenticatePin(string pin)
        {
            if (pin != this.pin)
                throw new Exception("Pin does not match");
        }
    }
}
