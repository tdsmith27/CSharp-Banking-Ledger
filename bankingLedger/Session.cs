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
                            Console.WriteLine("How much would you like to deposit?");
                            bool success = false;
                            string depositStr;
                            while (!success)
                            {

                                depositStr = Console.ReadLine();
                                if (Validate.Input(depositStr, "Deposit"))
                                {
                                    success = true;
                                    double deposit = double.Parse(depositStr);
                                    Transaction transaction = new Transaction("Deposit", deposit, account.balance + deposit);                                    
                                    account.balance += deposit;
                                    account.transactionLog.Add(transaction);
                                } else
                                {
                                    Console.WriteLine("Please enter a valid deposit amount");
                                }
                                
                                
                            }                            
                            break;
                        case "2":
                            validMenuChoice = true;
                            Console.WriteLine("You have selected: Make a withdrawal\n");
                            Console.WriteLine("How much would you like to withdraw?");
                            bool withdrawSuccess = false;

                            while (!withdrawSuccess)
                            {

                                try
                                {
                                    double withdrawal = Convert.ToDouble(Console.ReadLine());
                                    account.ValidateWithdrawal(withdrawal);
                                    withdrawSuccess = true;
                                    Transaction withdrawTransaction = new Transaction("Withdrawal", withdrawal, account.balance - withdrawal);
                                    account.balance -= withdrawal;
                                    account.transactionLog.Add(withdrawTransaction);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Please enter a valid withdrawal amount");
                                }
                            }

                            
                            break;
                        case "3":
                            validMenuChoice = true;
                            Console.WriteLine("You have selected: Check account balance\n");
                            Console.WriteLine($"Your account balance is ${account.balance}");
                            break;
                        case "4":
                            validMenuChoice = true;
                            Console.WriteLine("\nTransaction Log:\n");
                             for (int i = 0; i < account.transactionLog.Count; i++)
                            {
                                Transaction item = account.transactionLog[i];
                                Console.WriteLine($"{i + 1}: {item.Log()}");
                            }
                            break;
                        case "5":
                            validMenuChoice = true;
                            Console.Clear();
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
