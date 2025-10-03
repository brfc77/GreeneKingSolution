using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.ValidationRules
{
    public class LastNameRequiredRuleTests
    {
        private readonly LastNameRequiredRule _rule = new();

        [Theory]
        [InlineData(null, RegisterError.LastNameRequired)]   // null
        [InlineData("", RegisterError.LastNameRequired)]     // empty string
        [InlineData("   ", RegisterError.LastNameRequired)]  // whitespace
        [InlineData("Doe", null)]                            // valid last name
        public void Check_ShouldReturnExpected(string? lastName, RegisterError? expected)
        {
            var speaker = new Speaker { LastName = lastName };

            var result = _rule.Check(speaker);

            Assert.Equal(expected, result);
        }
    }

}