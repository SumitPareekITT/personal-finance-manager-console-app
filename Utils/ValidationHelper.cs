using System;

namespace PersonalFinanceManager.Utils
{
    public static class ValidationHelper
    {
        public static decimal ReadValidAmount()
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";

                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                {
                    return amount;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
                Console.ResetColor();
            }
        }

        public static DateTime ReadValidDate()
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";

                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format.");
                Console.ResetColor();
            }
        }

        public static string ReadNonEmptyInput(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty.");
                Console.ResetColor();
            }
        }
    }
}