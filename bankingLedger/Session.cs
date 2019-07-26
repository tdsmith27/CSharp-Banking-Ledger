using System;
namespace bankingLedger
{
    public class Session
    {
        Account account;

        public Session(Account account)
        {
            this.account = account;
        }

        public void Main()
        {
            Console.Clear();
            Format.Message($"You are logged in as {account.username}");
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("\nWhat would you like to do today?");
                Console.WriteLine("\t1 - Make a deposit");
                Console.WriteLine("\t2 - Make a withdrawal");
                Console.WriteLine("\t3 - Check account balance");
                Console.WriteLine("\t4 - View transaction log");
                Console.WriteLine("\t5 - Log out");

                bool validMenuChoice = false;

                while (!validMenuChoice)
                {

                    string menuChoice = Console.ReadLine();

                    switch (menuChoice)
                    {
                        case "1":
                            validMenuChoice = true;
                            this.Deposit();                            
                            break;
                        case "2":
                            validMenuChoice = true;
                            this.Withdraw();                            
                            break;
                        case "3":
                            validMenuChoice = true;
                            Console.WriteLine();
                            Format.Message($"Your account balance is ${account.CheckBalance()}");
                            break;
                        case "4":
                            validMenuChoice = true;
                            Console.WriteLine();
                            Format.Message("\nTransaction Log:\n");
                            account.LogTransactions(); 
                            break;
                        case "5":
                            validMenuChoice = true;
                            loggedIn = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine();
                            Format.Error("Please select an option from the list");
                            break;
                    }
                }
            }
        }

        void Deposit()
        {
            Console.WriteLine();
            Format.Prompt("How much would you like to deposit?\n(enter 0 to cancel transaction)");
            bool success = false;
            while (!success)
            {
                string deposit = Console.ReadLine();
                try
                {
                    Validate.Transaction(deposit);
                    if (deposit == "0")
                        break;
                    account.Deposit(decimal.Parse(deposit));                    
                    success = true;
                    Format.Message("\nDeposit Successful");
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Format.Error(e.Message);
                    Format.Error("Please enter a valid deposit amount\n(enter 0 to cancel transaction)");
                }
            }
        }

        void Withdraw()
        {
            Console.WriteLine();
            Format.Prompt("How much would you like to withdraw?\n(enter 0 to cancel transaction)");
            bool success = false;
            while (!success)
            {
                string withdrawal = Console.ReadLine();
                try
                {
                    Validate.Transaction(withdrawal);
                    if (withdrawal == "0")
                        break;
                    account.Withdraw(decimal.Parse(withdrawal));
                    success = true;
                    Format.Message("\nWithdrawal Successful");
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Format.Error(e.Message);
                    Format.Error("Please enter a valid withdrawal amount\n(enter 0 to cancel transaction)");
                }
            }
        }
    }    
}
