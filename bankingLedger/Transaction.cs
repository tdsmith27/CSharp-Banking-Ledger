using System;
namespace bankingLedger
{
    public class Transaction
    {
        DateTime time;
        public string type { get; private set; }
        public decimal amount { get; private set; }

        public Transaction(string type, decimal amount)
        {
            time = DateTime.Now;
            this.type = type;
            this.amount = amount;
        }

        public string Log()
        {
            return $"{this.time}: {this.type} - ${this.amount.ToString("n2")}";
        }

    }
}
