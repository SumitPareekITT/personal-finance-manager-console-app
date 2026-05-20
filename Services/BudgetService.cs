using System;
using System.Linq;
using PersonalFinanceManager.Database;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class BudgetService
    {
        private readonly AppDbContext _context;

        public BudgetService(AppDbContext context)
        {
            _context = context;
        }

        public void SetBudget()
        {
            Console.Write("Enter Category: ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Budget Amount: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal limitAmount) || limitAmount <= 0)
            {
                Console.WriteLine("Invalid budget amount.");
                return;
            }

            var existingBudget = _context.Budgets
                .FirstOrDefault(b => b.Category.ToLower() == category.ToLower());

            if (existingBudget != null)
            {
                existingBudget.LimitAmount = limitAmount;

                Console.WriteLine("Budget updated successfully.");
            }
            else
            {
                var budget = new Budget
                {
                    Category = category,
                    LimitAmount = limitAmount
                };

                _context.Budgets.Add(budget);

                Console.WriteLine("Budget added successfully.");
            }

            _context.SaveChanges();
        }

        public void ViewBudgets()
        {
            var budgets = _context.Budgets.ToList();

            if (!budgets.Any())
            {
                Console.WriteLine("No budgets found.");
                return;
            }

            foreach (var budget in budgets)
            {
                Console.WriteLine(
                    $"ID: {budget.Id} | Category: {budget.Category} | Budget Limit: {budget.LimitAmount}"
                );
            }
        }
    }
}