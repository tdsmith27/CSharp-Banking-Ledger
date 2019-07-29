using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        public string username { get; private set; }
        private string hash;
        private string salt;
        public List<Transaction> transactionLog { get; private set; }

        public Account(string username, string password)
        {
            this.username = username;
            this.SavePassword(password);
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

        private void SavePassword(string password)
        {
            try
            {
                string salt = Salt.Create();
                string hash = Hash.Create(password, salt);

                this.salt = salt;
                this.hash = hash;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AuthenticatePassword(string password)
        {
            if (!Hash.Authenticate(password, salt, hash))
                throw new Exception("Password does not match");
        }
    }
}
