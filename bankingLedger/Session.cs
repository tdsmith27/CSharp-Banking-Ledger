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
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine($"You are logged in as {account.username}");
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
                            Console.WriteLine("You have selected: Make a deposit");
                            validMenuChoice = true;
                            break;
                        case "2":
                            Console.WriteLine("You have selected: Make a withdrawal");
                            validMenuChoice = true;
                            break;
                        case "3":
                            Console.WriteLine("You have selected: Check account balance");
                            validMenuChoice = true;
                            break;
                        case "4":
                            Console.WriteLine("You have selected: View transaction log");
                            validMenuChoice = true;
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
    }
}
