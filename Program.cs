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
var authService = new AuthService(context);

bool isLoggedIn = false;

while (!isLoggedIn)
{
    Console.WriteLine("\n=== Authentication ===");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");

    Console.Write("Select an option: ");

    string authChoice = Console.ReadLine() ?? "";

    switch (authChoice)
    {
        case "1":
            authService.Register();
            break;

        case "2":
            isLoggedIn = authService.Login();
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

var expenseService = new ExpenseService(context, authService.LoggedInUserId);

var incomeService = new IncomeService(context, authService.LoggedInUserId);

var budgetService = new BudgetService(context, authService.LoggedInUserId);

var summaryService = new SummaryService(context, authService.LoggedInUserId);

while (true)
{
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View Expenses");
    Console.WriteLine("3. Delete Expense");
    Console.WriteLine("4. Add Income");
    Console.WriteLine("5. View Income");
    Console.WriteLine("6. Set Budget");
    Console.WriteLine("7. View Budgets");
    Console.WriteLine("8. Financial Summary");
    Console.WriteLine("9. Category-wise Spending");
    Console.WriteLine("10. Exit");

    Console.Write("Select an option: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            expenseService.AddExpense();
            break;

        case "2":

            Console.WriteLine("\n=== Expense View Options ===");
            Console.WriteLine("1. View All Expenses");
            Console.WriteLine("2. Filter By Category");
            Console.WriteLine("3. Filter By Date");

            Console.Write("Select an option: ");

            string expenseViewChoice = Console.ReadLine() ?? "";

            switch (expenseViewChoice)
            {
                case "1":
                    expenseService.ViewExpenses();
                    break;

                case "2":
                    expenseService.FilterExpensesByCategory();
                    break;

                case "3":
                    expenseService.FilterExpensesByDate();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            break;

        case "3":
            expenseService.DeleteExpense();
            break;

        case "4":
            incomeService.AddIncome();
            break;

        case "5":
            incomeService.ViewIncome();
            break;

        case "6":
            budgetService.SetBudget();
            break;

        case "7":
            budgetService.ViewBudgets();
            break;

        case "8":
            summaryService.ShowFinancialSummary();
            break;

        case "9":
            summaryService.ShowCategoryWiseSpending();
            break;

        case "10":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}