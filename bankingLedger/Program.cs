using System;
using System.Collections.Generic;


namespace bankingLedger
{
    class Program
    {

        public static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            bool programComplete = false;
            

            while (!programComplete)
            {
                Console.WriteLine("Welcome. What would you like to do?");
                Console.WriteLine("\t1 - Login");
                Console.WriteLine("\t2 - Create an Account");
                Console.WriteLine("\t3 - Exit Program");

                bool validMenuChoice = false;
            
                while (!validMenuChoice)
                {

                    string menuChoice = Console.ReadLine();

                    switch (menuChoice)
                    {
                        case "1":
                            validMenuChoice = true;
                            break;
                        case "2":
                            Console.WriteLine("You have chosen to Create an Account");
                            CreateAccount();
                            validMenuChoice = true;
                            break;
                        case "3":
                            Console.WriteLine("Thank you for using the program\n\n\tHave a nice day!");
                            validMenuChoice = true;
                            programComplete = true;
                            break;
                        default:
                            Console.WriteLine("Please select an option from the list");
                            break;
                    }
                }
            }
        }

        //static void Login()
        //{
        //    string username; int pin;

        //    Console.Clear();
        //    Console.WriteLine("Please enter your username");
        //    username = Console.ReadLine();


        //}

        static void CreateAccount()
        {
            Console.WriteLine("Please type in your desired username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter a 4 digit numeric pin");
            Console.Write("pin: ");
            string pin = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write("\n");
                    break;
                }
                Console.Write("*");
                pin += key.KeyChar;
            }
            Account account = new Account(username, pin);
            accounts.Add(account);

                       


        }
    }
}
