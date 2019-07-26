using System;
namespace bankingLedger
{
    public class Authenticate
    {
        public static Account Username(string username)
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
