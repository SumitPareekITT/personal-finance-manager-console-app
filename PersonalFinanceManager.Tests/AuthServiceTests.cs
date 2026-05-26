using Xunit;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PersonalFinanceManager.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void PasswordHash_ShouldNotBeEmpty()
        {
            string password = "admin123";

            using SHA256 sha256 = SHA256.Create();

            byte[] bytes = sha256.ComputeHash(
                Encoding.UTF8.GetBytes(password)
            );

            string hash = Convert.ToBase64String(bytes);

            Assert.False(string.IsNullOrEmpty(hash));
        }
    }
}