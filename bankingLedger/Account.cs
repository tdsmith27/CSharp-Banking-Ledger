using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        public string username { get; private set; }
        public string pin { private get; set; }
        public List<Transaction> transactionLog { get; private set; }

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
            decimal balance = 0;
            Format.Message("\nTransaction Log:");
            for (int i = 0; i < transactionLog.Count; i++)
            {
                var transaction = transactionLog[i];

                if (transaction.type == "Deposit")
                {
                    balance += transaction.amount;
                }
                if (transaction.type == "Withdrawal")
                {
                    balance -= transaction.amount;
                }
                Format.Message($"{transaction.time} - {transaction.type}: {transaction.amount.ToString("n2")} - Balance: {balance.ToString("n2")} ");

            }
        }

        public void AuthenticatePassword(string pin)
        {
            if (pin != this.pin)
                throw new Exception("Password does not match");
        }
    }
}
