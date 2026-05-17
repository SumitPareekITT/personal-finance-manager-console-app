using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalFinanceManager.Database;
using PersonalFinanceManager.Services;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .Options;

using var context = new AppDbContext(options);

var expenseService = new ExpenseService(context);

while (true)
{
    Console.WriteLine("\n=== Personal Finance Manager ===");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View Expenses");
    Console.WriteLine("3. Filter Expenses By Category");
    Console.WriteLine("4. Filter Expenses By Date");
    Console.WriteLine("5. Exit");

    Console.Write("Select an option: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            expenseService.AddExpense();
            break;

        case "2":
            expenseService.ViewExpenses();
            break;

        case "3":
            expenseService.FilterExpensesByCategory();
            break;

        case "4":
            expenseService.FilterExpensesByDate();
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}