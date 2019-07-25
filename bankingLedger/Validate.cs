﻿using System;
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
                    case "Pin":
                        Pin(input);
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

        static void Transaction(string deposit)
        {            
            if (!Regex.IsMatch(deposit, @"^[0-9]*\.?[0-9]{0,2}$"))
            {
                throw new Exception("Transaction amount must be a positive number with up to 2 decimal places");
            } if (deposit == "0")
            {
                throw new Exception("Transaction amount cannot be 0");
            }            
        }

        static void Pin(string pin)
        {
            if (!Regex.IsMatch(pin, @"^[0-9]{4}$"))
            {
                throw new Exception("Pin must be 4 numbers 0-9");
            }
        }
    }
}
