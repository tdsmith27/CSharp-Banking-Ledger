using System;
namespace bankingLedger
{
    public class Validate
    {
        public static bool Deposit(string deposit)
        {
            try
            {
                double amount = double.Parse(deposit);
                if (amount > 0)
                {
                return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Input(string input, string type)
        {
            switch (type)
            {
                case "Deposit":
                    return Deposit(input);                   
                    break;
                default:
                    return false;
                    break;
            }
        }
    }
}
