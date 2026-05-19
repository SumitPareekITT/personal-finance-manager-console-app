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
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

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

        public void FilterExpensesByCategory()
        {
            Console.Write("Enter Category: ");
            string category = Console.ReadLine() ?? string.Empty;

            var expenses = _context.Expenses
                .Where(e => e.Category.ToLower() == category.ToLower())
                .ToList();

            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found for this category.");
                return;
            }

            foreach (var expense in expenses)
            {
                Console.WriteLine(
                    $"ID: {expense.Id} | Amount: {expense.Amount} | Category: {expense.Category} | Date: {expense.Date}"
                );
            }
        }

        public void FilterExpensesByDate()
        {
            Console.Write("Enter Date (yyyy-mm-dd): ");

            string inputDate = Console.ReadLine() ?? "";

            if (!DateTime.TryParse(inputDate, out DateTime selectedDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            var expenses = _context.Expenses
                .Where(e => e.Date.Date == selectedDate.Date)
                .ToList();

            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found for this date.");
                return;
            }

            foreach (var expense in expenses)
            {
                Console.WriteLine(
                    $"ID: {expense.Id} | Amount: {expense.Amount} | Category: {expense.Category} | Date: {expense.Date}"
                );
            }
        }

        public void DeleteExpense()
        {
            Console.Write("Enter Expense ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int expenseId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var expense = _context.Expenses.FirstOrDefault(e => e.Id == expenseId);

            if (expense == null)
            {
                Console.WriteLine("Expense not found.");
                return;
            }

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            Console.WriteLine("Expense deleted successfully.");
        }
    }
}