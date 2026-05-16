using System;
using System.Linq;
using PersonalFinanceManager.Database;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class ExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public void AddExpense()
        {
            Console.Write("Enter Amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Category: ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Description: ");
            string description = Console.ReadLine() ?? string.Empty;

            var expense = new Expense
            {
                Amount = amount,
                Category = category,
                Description = description,
                Date = DateTime.Now
            };

            _context.Expenses.Add(expense);
            _context.SaveChanges();

            Console.WriteLine("Expense added successfully.");
        }

        public void ViewExpenses()
        {
            var expenses = _context.Expenses.ToList();

            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            foreach (var expense in expenses)
            {
                Console.WriteLine(
                    $"ID: {expense.Id} | Amount: {expense.Amount} | Category: {expense.Category} | Date: {expense.Date}"
                );
            }
        }
    }
}