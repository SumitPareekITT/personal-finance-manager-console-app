# Personal Finance Manager (Console Application)

A console-based Personal Finance Manager application built using **.NET 8**, **Entity Framework Core**, and **MySQL**.  
The application helps users manage expenses, income, budgets, and financial summaries with secure authentication and persistent database storage.

---

# Features

## Authentication Module
- User Registration
- User Login
- Password Hashing using SHA256
- User-specific data access

---

## Expense Management
- Add Expense
- View Expenses
- Filter Expenses by Category
- Filter Expenses by Date
- Delete Expense
- Category-wise expense tracking
- Expense sorting by latest date
- Budget exceed warning

---

## Income Management
- Add Income
- View Income
- Income validation

---

## Budget Management
- Set Budget
- Update Existing Budget
- View Budgets
- Budget limit validation

---

## Financial Summary
- Total Income Calculation
- Total Expense Calculation
- Remaining Balance Calculation
- Category-wise Spending Summary

---

## Validation & Console Utilities
- Amount validation
- Date validation
- Empty input validation
- Currency formatting
- Improved console formatting

---

## Database Features
- MySQL Database Integration
- Entity Framework Core ORM
- Database Migrations
- User-wise relational data management
- Foreign Key Relationships

---

## Testing
- xUnit Test Framework
- Validation Tests
- Summary Calculation Tests
- Authentication Hashing Tests
- Expense Validation Tests

---

# Tech Stack

| Technology | Usage |
|---|---|
| .NET 8 | Console Application Framework |
| C# | Backend Language |
| Entity Framework Core | ORM |
| MySQL | Database |
| xUnit | Unit Testing |
| Pomelo.EntityFrameworkCore.MySql | MySQL Provider |

---

# Project Structure

```text
personal-finance-manager-console-app/
│
├── Models/
│   ├── Expense.cs
│   ├── Income.cs
│   ├── Budget.cs
│   ├── Category.cs
│   └── User.cs
│
├── Services/
│   ├── ExpenseService.cs
│   ├── IncomeService.cs
│   ├── BudgetService.cs
│   ├── SummaryService.cs
│   └── AuthService.cs
│
├── Database/
│   └── AppDbContext.cs
│
├── Utils/
│   ├── ValidationHelper.cs
│   └── ConsoleHelper.cs
│
├── PersonalFinanceManager.Tests/
│   ├── AuthServiceTests.cs
│   ├── ExpenseServiceTests.cs
│   ├── SummaryServiceTests.cs
│   └── ValidationHelperTests.cs
│
├── Program.cs
├── appsettings.json
└── README.md