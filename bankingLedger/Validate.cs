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

        public static void Password(string password)
        {
            if (!Regex.IsMatch(password, @"^[\S]{6,}"))
            {
                throw new Exception("Password must be at least 6 characters long with no whitespaces");
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

        public static Account ExistingUsername(string username)
        {
            foreach (var account in Program.accounts)
            {
                if (account.username == username)
                {
                    return account;
                }
            }
            throw new Exception("Username not found - would you like to create an account?\nRemember, usernames are case-sensitive");
        }
    }
}
