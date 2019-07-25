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

            throw new Exception("Username not found");
        }

        public static void NewUsername(string username)
        {
            foreach (var account in Program.accounts)
            {
                if (account.username == username)
                {
                    throw new Exception("That username already exists");
                }
            }
        }

        //public static void Pin(string pin, Account account)
        //{
        //    if (pin != account.pin)
        //        throw new Exception("Pin does not match");
        //}
    }
}
