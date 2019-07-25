using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        public string username;
        public string pin;
        List<Transaction> transactionLog;
        double balance;

        public Account(string username, string pin)
        {
            this.username = username;
            this.pin = pin;
            this.transactionLog = new List<Transaction>();
            this.balance = 0;
        }      

        public void Deposit(double amount)
        {
            var transaction = new Transaction("Deposit", amount, this.balance + amount);
            this.balance += amount;
            this.transactionLog.Add(transaction);
        }

        public void Withdraw (double amount)
        {
            if (amount > this.balance)
            {
                throw new Exception("Not enough funds");
            }
            var transaction = new Transaction("Withdrawal", amount, this.balance - amount);
            this.balance -= amount;
            this.transactionLog.Add(transaction);            
        }

        public double CheckBalance()
        {
            return balance;
        }

        public void LogTransactions()
        {
            for (int i = 0; i < transactionLog.Count; i++)
            {
                var transaction = transactionLog[i];
                Console.WriteLine($"{i + 1}: {transaction.Log()}");
            }
        }
    }
}
