using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bankingLedger
{
    public static class Validate
    {                
        public static void Transaction(string deposit)
        {            
            if (!Regex.IsMatch(deposit, @"^[0-9]*\.?[0-9]{0,2}$"))
            {
                throw new Exception("Transaction amount must be a positive number with up to 2 decimal places");
            }            
        }

        public static void Pin(string pin)
        {
            if (!Regex.IsMatch(pin, @"^[0-9]{4}$"))
            {
                throw new Exception("Pin must be 4 numbers 0-9");
            }
        }        

        public static void NewUsername(string username)
        {
            foreach (var account in Program.accounts)
            {
                if (account.username == username)
                {
                    throw new Exception("That username already exists - would you like to log in?");
                }
            }
        }
    }
}
