using System;
namespace bankingLedger
{
    public class Transaction
    {
        public DateTime time { get; private set; }
        public string type { get; private set; }
        public decimal amount { get; private set; }

        public Transaction(string type, decimal amount)
        {
            time = DateTime.Now;
            this.type = type;
            this.amount = amount;
        }       
    }
}
