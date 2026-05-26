using Xunit;

namespace PersonalFinanceManager.Tests
{
    public class ExpenseServiceTests
    {
        [Fact]
        public void ExpenseAmount_ShouldBeGreaterThanZero()
        {
            decimal amount = -100;

            Assert.True(amount > 0);
        }
    }
}