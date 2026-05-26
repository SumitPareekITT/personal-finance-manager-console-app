using Xunit;

namespace PersonalFinanceManager.Tests
{
    public class ValidationHelperTests
    {
        [Fact]
        public void PositiveAmount_ShouldBeValid()
        {
            decimal amount = 100;

            Assert.True(amount > 0);
        }

        [Fact]
        public void NegativeAmount_ShouldBeInvalid()
        {
            decimal amount = -100;

            Assert.False(amount > 0);
        }
    }
}