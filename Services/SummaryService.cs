using System;
using System.Linq;
using PersonalFinanceManager.Database;

namespace PersonalFinanceManager.Services
{
    public class SummaryService
    {
        private readonly AppDbContext _context;

        public SummaryService(AppDbContext context)
        {
            _context = context;
        }

        public void ShowFinancialSummary()
        {
            decimal totalIncome = _context.Incomes.Sum(i => i.Amount);

            decimal totalExpense = _context.Expenses.Sum(e => e.Amount);

            decimal balance = totalIncome - totalExpense;

            Console.WriteLine("\n=== Financial Summary ===");

            Console.WriteLine($"Total Income  : ₹{totalIncome:N2}");
            Console.WriteLine($"Total Expense : ₹{totalExpense:N2}");
            Console.WriteLine($"Balance       : ₹{balance:N2}");
        }

        public void ShowCategoryWiseSpending()
        {
            var categorySummary = _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                })
                .ToList();

            if (!categorySummary.Any())
            {
                Console.WriteLine("No expense records found.");
                return;
            }

            Console.WriteLine("\n=== Category-wise Spending ===");

            foreach (var item in categorySummary)
            {
                Console.WriteLine($"{item.Category} : {item.Total}");
            }
        }
    }
}