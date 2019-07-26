using System;
namespace bankingLedger
{
    public class Format
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
                        if (pin == null)
                            break;
                        pin = pin.Substring(0, pin.Length - 1);
                        Console.Write("\b \b");                        
                        break;
                    case ConsoleKey.Enter:
                        try
                        {
                            if (pin == null)
                            {
                                break;
                            }
                            Validate.Pin(pin);
                            isValid = true;
                            Console.Write("\n");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\n");
                            Format.Error(e.Message);
                            Format.Error("Please enter a valid pin");
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
