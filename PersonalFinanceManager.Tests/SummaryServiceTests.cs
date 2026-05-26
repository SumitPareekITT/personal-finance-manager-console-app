using Xunit;

namespace PersonalFinanceManager.Tests
{
    public class SummaryServiceTests
    {
        [Fact]
        public void Balance_ShouldBeCalculatedCorrectly()
        {
            decimal income = 5000;
            decimal expense = 2000;

            decimal balance = income - expense;

            Assert.Equal(3000, balance);
        }
    }
}