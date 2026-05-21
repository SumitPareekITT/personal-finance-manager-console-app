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

            Console.WriteLine($"Total Income  : {totalIncome}");

            Console.WriteLine($"Total Expense : {totalExpense}");

            Console.WriteLine($"Balance       : {balance}");
        }
    }
}