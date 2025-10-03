using GreeneKingSpeaker.Calculators;
using Xunit;

namespace GreeneKingSpeakerTests.Calculators
{
    public class FeeCalculatorTests
    {
        [Theory]
        [InlineData(0, 500)]
        [InlineData(1, 500)]
        [InlineData(2, 250)]
        [InlineData(3, 250)]
        [InlineData(5, 100)]
        [InlineData(6, 50)]
        [InlineData(9, 50)]
        [InlineData(10, 0)]
        [InlineData(20, 0)]
        public void FeeCalculator_Tiers_Work(int input, int expected)
        {
            var calc = new FeeCalculator();
            Assert.Equal(expected, calc.CalculateFee(input));
        }

    }
}