using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public List<Expense> Expenses { get; set; } = new();

        public List<Income> Incomes { get; set; } = new();

        public List<Budget> Budgets { get; set; } = new();
    }
}