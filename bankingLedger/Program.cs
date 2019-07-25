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
                Console.Clear();
                Console.WriteLine("Welcome. What would you like to do?");
                Console.WriteLine("\t1 - Login");
                Console.WriteLine("\t2 - Create an Account");
                Console.WriteLine("\t3 - Exit Program");

                bool isValidMenuChoice = false;
            
                while (!isValidMenuChoice)
                {

                    string menuChoice = Console.ReadLine();

                    switch (menuChoice)
                    {
                        case "1":
                            Login();
                            isValidMenuChoice = true;
                            break;
                        case "2":
                            Console.WriteLine("You have chosen to Create an Account");
                            CreateAccount();
                            isValidMenuChoice = true;
                            break;
                        case "3":
                            Console.WriteLine("Thank you for using the program\n\n\tHave a nice day!");
                            isValidMenuChoice = true;
                            programComplete = true;
                            break;
                        default:
                            Console.WriteLine("Please select an option from the list");
                            break;
                    }
                }
            }
        }

        static void Login()
        {                       
            Console.WriteLine("Please enter your username");
            bool isValidUsername = false;

            while (!isValidUsername)
            {
                string username = Console.ReadLine();
                try
                {
                    var account = Authenticate.Username(username);
                    isValidUsername = true;

                    bool isMatch = false;

                    while(!isMatch)
                    {
                        try
                        {
                            Console.WriteLine("Please enter your pin");
                            Console.Write("pin: ");
                            string pin = Format.Pin();
                            Authenticate.Pin(pin, account);
                            isMatch = true;
                        }
                        catch (Exception e)
                        {
                            var errors = new string[2] { e.Message, "Please try again" };
                            Format.Error(errors);
                        }
                    }

                    var session = new Session(account);
                    session.Main();

                }
                catch (Exception e)
                {
                    var errors = new string[2] { e.Message, "Please try again" };
                    Format.Error(errors);
                }
            }



        }

        static void CreateAccount()
        {
            Console.WriteLine("\nPlease type in your desired username");
            string username = Console.ReadLine();           

            Console.WriteLine("Please enter a 4 digit numeric pin");
            Console.Write("pin: ");
            string pin = Format.Pin();
                            
            Account account = new Account(username, pin);
            accounts.Add(account);

            Session session = new Session(account);
            session.Main();
                       
        }      
    }
}
