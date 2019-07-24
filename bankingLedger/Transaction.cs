using System;
namespace bankingLedger
{
    public class Transaction
    {
        string type { get; set; }
        double amount;
        double resultingBalance;

        public Transaction(string type, double amount, double resultingBalance)
        {
            this.type = type;
            this.amount = amount;
            this.resultingBalance = resultingBalance;
        }

        //public Transaction(string type)
        //{
        //    this.type = type;
        //}

        public string Log()
        {
            return $"{this.type} of ${this.amount.ToString("n2")} resulting in a balance of ${this.resultingBalance.ToString("n2")}";
        }
        
    }
}
