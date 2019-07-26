using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        public string username { get; private set; }
        public string pin { private get; set; }
        List<Transaction> transactionLog;

        public Account(string username, string pin)
        {
            this.username = username;
            this.pin = pin;
            transactionLog = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            var transaction = new Transaction("Deposit", amount);
            transactionLog.Add(transaction);
        }

        public void Withdraw (decimal amount)
        {
            decimal balance = CheckBalance();
            if (amount > balance)
            {
                throw new Exception("Not enough funds");
            }
            var transaction = new Transaction("Withdrawal", amount);
            transactionLog.Add(transaction);            
        }

        public decimal CheckBalance()
        {
            decimal balance = 0;

            foreach (var transaction in transactionLog)
            {
                if (transaction.type == "Deposit")
                {
                    balance += transaction.amount;
                }
                if (transaction.type == "Withdrawal")
                {
                    balance -= transaction.amount;
                }
            }

            return balance;
        }

        public void LogTransactions()
        {
            for (int i = 0; i < transactionLog.Count; i++)
            {
                var transaction = transactionLog[i];
                Format.Message($"{i + 1} - {transaction.Log()}");                
            }
        }

        public void AuthenticatePin(string pin)
        {
            if (pin != this.pin)
                throw new Exception("Pin does not match");
        }
    }
}
