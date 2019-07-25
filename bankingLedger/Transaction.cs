using System;
namespace bankingLedger
{
    public class Transaction
    {
        DateTime time;
        string type;
        decimal amount;
        decimal resultingBalance;

        public Transaction(string type, decimal amount, decimal resultingBalance)
        {
            this.time = DateTime.Now;
            this.type = type;
            this.amount = amount;
            this.resultingBalance = resultingBalance;
        }        

        public string Log()
        {
            return $"{this.time}: {this.type} of ${this.amount.ToString("n2")} resulting in a balance of ${this.resultingBalance.ToString("n2")}";
        }
        
    }
}
