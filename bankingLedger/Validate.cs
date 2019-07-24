using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bankingLedger
{
    public class Validate
    {        
        public static void Input(string input, string type)
        {
            try
            {

                switch (type)
                {
                    case "Transaction":
                        Transaction(input);                   
                        break;
                    default:                    
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Transaction(string deposit)
        {            
            if (!Regex.IsMatch(deposit, @"^[1-9]{1}[0-9]*\.?[0-9]{0,2}$"))
            {
                throw new Exception("Transaction amount must be a positive number with up to 2 decimal places");
            }            
        }        
    }
}
