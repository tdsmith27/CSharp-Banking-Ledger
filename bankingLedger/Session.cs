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
            Console.WriteLine($"You are logged in as {account.username}");
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
                            Console.WriteLine($"Your account balance is ${account.CheckBalance()}");
                            break;
                        case "4":
                            validMenuChoice = true;
                            Console.WriteLine("\nTransaction Log:\n");
                            account.LogTransactions(); 
                            break;
                        case "5":
                            validMenuChoice = true;
                            loggedIn = false;
                            break;
                        default:
                            Console.WriteLine("Please select an option from the list");
                            break;
                    }
                }
            }
        }

        void Deposit()
        {
            Console.WriteLine("How much would you like to deposit?");
            bool success = false;
            while (!success)
            {
                string deposit = Console.ReadLine();
                try
                {
                    Validate.Input(deposit, "Transaction");
                    account.Deposit(double.Parse(deposit));
                    success = true;
                }
                catch (Exception e)
                {
                    var errors = new string[2] { e.Message, "Please enter a valid deposit amount" };
                    Format.Error(errors);
                }
            }
        }

        void Withdraw()
        {
            Console.WriteLine("How much would you like to withdraw?");
            bool success = false;
            while (!success)
            {
                string withdrawal = Console.ReadLine();
                try
                {
                    Validate.Input(withdrawal, "Transaction");
                    account.Withdraw(double.Parse(withdrawal));
                    success = true;
                }
                catch (Exception e)
                {
                    var errors = new string[2] { e.Message, "Please enter a valid withdrawal amount" };
                    Format.Error(errors);                    
                }
            }
        }
    }    
}
