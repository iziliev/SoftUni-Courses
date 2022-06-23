using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Money_Transactions
{
    public class StartUp
    {
        public static string[] commands = new string[] { "Deposit", "Withdraw" };
        public static void Main()
        {
            var accounts = new Dictionary<int, double>();

            FillAccounts(accounts);

            var input = string.Empty;
            while ((input = Console.ReadLine()) !="End")
            {
                var inputArgs = input.Split(' ');

                try
                {
                    if (IsCommandCorrect(inputArgs[0]))
                    {
                        if (inputArgs[0] == commands[0])
                        {
                            Deposit(accounts, inputArgs);
                        }
                        else if (inputArgs[0] == commands[1])
                        {
                            Withdraw(accounts, inputArgs);
                        }
                    }
                    else
                    {
                        throw new ArgumentException(ExeptionMessage.commandEx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static void Withdraw(Dictionary<int, double> accounts, string[] inputArgs)
        {
            var accountNumber = int.Parse(inputArgs[1]);
            var sum = double.Parse(inputArgs[2]);

            if (!accounts.ContainsKey(accountNumber))
            {
                throw new ArgumentException(ExeptionMessage.accountEx);
            }
            else if (accounts[accountNumber] < sum)
            {
                throw new ArgumentException(ExeptionMessage.balanceEx);
            }
            else
            {
                accounts[accountNumber] -= sum;
                PrintAccount(accounts, accountNumber);
            }
        }

        private static void PrintAccount(Dictionary<int, double> accounts, int accountNumber)
        {
            Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
        }

        private static void Deposit(Dictionary<int, double> accounts, string[] inputArgs)
        {
            var accountNumber = int.Parse(inputArgs[1]);
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber] += double.Parse(inputArgs[2]);
                PrintAccount(accounts, accountNumber);
            }
            else
            {
                throw new ArgumentException(ExeptionMessage.accountEx);
            }
        }

        private static bool IsCommandCorrect(string command)
        {
            return commands.Contains(command);
        }

        private static void FillAccounts(Dictionary<int, double> accounts)
        {
            var input = Console.ReadLine().Split(",");
            for (int i = 0; i < input.Length; i++)
            {
                var args = input[i].Split('-');
                var account = int.Parse(args[0]);
                var amount = double.Parse(args[1]);

                accounts.Add(account, amount);
            }
        }
    }
}
