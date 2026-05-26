using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PersonalFinanceManager.Database;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public int LoggedInUserId { get; private set; }

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public void Register()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine() ?? "";

            if (_context.Users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine() ?? "";

            string passwordHash = HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            Console.WriteLine("Registration successful.");
        }

        public bool Login()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Enter Password: ");
            string password = Console.ReadLine() ?? "";

            string passwordHash = HashPassword(password);

            var user = _context.Users.FirstOrDefault(
                u => u.Username == username &&
                     u.PasswordHash == passwordHash
            );

            if (user == null)
            {
                Console.WriteLine("Invalid credentials.");
                return false;
            }

            LoggedInUserId = user.Id;

            Console.WriteLine("Login successful.");
            return true;
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] bytes = sha256.ComputeHash(
                Encoding.UTF8.GetBytes(password)
            );

            return Convert.ToBase64String(bytes);
        }
    }
}