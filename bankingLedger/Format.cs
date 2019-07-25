using System;
namespace bankingLedger
{
    public class Format
    {
        public static void Error(string[] args)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var message in args)
            {
                Console.WriteLine(message);
            }
            Console.ResetColor();
        }

        public static void Prompt(string prompt)
        {            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        public static string Pin()
        {
            string pin = null;
            bool isValid = false;

            while (!isValid)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        pin = pin.Substring(0, pin.Length - 1);
                        Console.Write("\b \b");
                        break;
                    case ConsoleKey.Enter:
                        try
                        {
                            Validate.Input(pin, "Pin");
                            isValid = true;
                            Console.Write("\n");
                            break;
                        }
                        catch (Exception e)
                        {
                            var errors = new string[2] { e.Message, "Please enter a valid pin" };
                            Console.WriteLine("\n");
                            Format.Error(errors);
                            pin = null;
                            break;
                        }
                    default:
                        Console.Write("*");
                        pin += key.KeyChar;
                        break;
                }
            }

            return pin;

        }

    }
}
