using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.ValidationRules;

public class FirstNameRequiredRuleTests
{
    private readonly FirstNameRequiredRule _rule = new();

    [Theory]
    [InlineData(null, RegisterError.FirstNameRequired)]   // null
    [InlineData("", RegisterError.FirstNameRequired)]     // empty string
    [InlineData("   ", RegisterError.FirstNameRequired)]  // whitespace
    [InlineData("John", null)]                            // valid name
    public void Check_ShouldReturnExpected(string? firstName, RegisterError? expected)
    {
        var speaker = new Speaker { FirstName = firstName };

        var result = _rule.Check(speaker);

        Assert.Equal(expected, result);
    }
}