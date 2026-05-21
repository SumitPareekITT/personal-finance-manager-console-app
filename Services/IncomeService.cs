using System;
using System.Linq;
using PersonalFinanceManager.Database;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class IncomeService
    {
        private readonly AppDbContext _context;

        public IncomeService(AppDbContext context)
        {
            _context = context;
        }

        public void AddIncome()
        {
            Console.Write("Enter Amount: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Console.Write("Enter Source: ");
            string source = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Description: ");
            string description = Console.ReadLine() ?? string.Empty;

            var income = new Income
            {
                Amount = amount,
                Source = source,
                Description = description,
                Date = DateTime.Now
            };

            _context.Incomes.Add(income);
            _context.SaveChanges();

            Console.WriteLine("Income added successfully.");
        }

        public void ViewIncome()
        {
            var incomes = _context.Incomes.ToList();

            if (!incomes.Any())
            {
                Console.WriteLine("No income records found.");
                return;
            }

            foreach (var income in incomes)
            {
                Console.WriteLine(
                    $"ID: {income.Id} | Amount: {income.Amount} | Source: {income.Source} | Date: {income.Date}"
                );
            }
        }
    }
}