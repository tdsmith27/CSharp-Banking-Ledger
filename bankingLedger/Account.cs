using System;
using System.Collections.Generic;

namespace bankingLedger
{
    public class Account
    {
        // NOTE: these should not be public and should be ENCAPSULATED within the Account class
        public string username;
        public string pin;
        public List<Transaction> transactionLog;
        public double balance;

        public Account(string username, string pin)
        {
            this.username = username;
            this.pin = pin;
            this.transactionLog = new List<Transaction>();
            this.balance = 0;
        }

        public void ValidateWithdrawal(double amount)
        {
            if (amount > this.balance)
                throw new ArgumentException("Cannot withdraw more than is in the balance");          
        }
    }
}
