using System;
namespace bankingLedger
{
    public static class Format
    {
        public static void Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        public static void Prompt(string prompt)
        {            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        public static void Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string Password()
        {
            string password = null;
            bool isValid = false;

            while (!isValid)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (password == null)
                            break;
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");                        
                        break;
                    case ConsoleKey.Enter:
                        try
                        {
                            if (password == null)
                            {
                                break;
                            }
                            Validate.Password(password);
                            isValid = true;
                            Console.Write("\n");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\n");
                            Format.Error(e.Message);
                            Format.Error("Please enter a valid password");
                            password = null;
                            break;
                        }
                    default:
                        Console.Write("*");
                        password += key.KeyChar;
                        break;
                }
            }

            return password;

        }

    }
}
