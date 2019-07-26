﻿using System;
using System.Collections.Generic;


namespace bankingLedger
{
    static class Program
    {

        public static List<Account> accounts = new List<Account> {new Account("trevor", "1234") };

        static void Main(string[] args)
        {
            bool programComplete = false;
            
            while (!programComplete)
            {
                Console.WriteLine("What would you like to do?");
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
                            CreateAccount();
                            isValidMenuChoice = true;
                            break;
                        case "3":
                            Console.WriteLine("\nThank you for using the program\nHave a nice day!\n");
                            isValidMenuChoice = true;
                            programComplete = true;
                            break;
                        default:
                            Console.WriteLine();
                            Format.Error("Please select an option from the list");
                            break;
                    }
                }
            }
        }

        static void Login()
        {
            Console.WriteLine();
            Format.Prompt("Please enter your username");
            Console.Write("username: ");
            string username = Console.ReadLine();            
            try
            {
                var account = Authenticate.Username(username);
                bool isMatch = false;

                while(!isMatch)
                {
                    try
                    {
                        Format.Prompt("Please enter your pin");
                        Console.Write("pin: ");
                        string pin = Format.Pin();
                        account.AuthenticatePin(pin);
                        isMatch = true;

                        var session = new Session(account);
                        session.Main();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Format.Error(e.Message);
                        Format.Error("Please try again");
                    }
                }                    
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Format.Error(e.Message);
            }
        }

        static void CreateAccount()
        {
            Format.Prompt("\nPlease type in your desired username (usernames are case-sensitive)");
            Console.Write("username: ");
            string username = Console.ReadLine();

            try
            {
                Validate.NewUsername(username);

                Format.Prompt("Please enter a 4 digit numeric pin");
                Console.Write("pin: ");
                string pin = Format.Pin();
                            
                Account account = new Account(username, pin);
                accounts.Add(account);

                Session session = new Session(account);
                session.Main();
            } catch (Exception e)
            {
                Console.WriteLine();
                Format.Error(e.Message);
            }
        }
    }
}
