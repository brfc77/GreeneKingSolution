using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.ValidationRules;

public class EmailRequiredRuleTests
{
    private readonly EmailRequiredRule _rule = new();

    [Theory]
    [InlineData(null, RegisterError.EmailRequired)]      // null email
    [InlineData("", RegisterError.EmailRequired)]        // empty email
    [InlineData("   ", RegisterError.EmailRequired)]     // whitespace only
    [InlineData("test@example.com", null)]               // valid email
    public void Check_ShouldReturnExpected(string? email, RegisterError? expected)
    {
        var speaker = new Speaker { Email = email };

        var result = _rule.Check(speaker);

        Assert.Equal(expected, result);
    }
}