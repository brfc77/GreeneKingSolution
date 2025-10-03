using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules;

public class EmployerRuleTests
{
    private readonly EmployerRule _rule = new();

    [Theory]
    [InlineData("Pluralsight", true)]  // preferred
    [InlineData("Microsoft", true)]    // preferred
    [InlineData("Google", true)]       // preferred
    [InlineData("Amazon", false)]      // not preferred
    [InlineData("AcmeCorp", false)]    // arbitrary not preferred
    [InlineData("", false)]            // empty string
    public void IsQualified_ShouldReturnExpected(string employer, bool expected)
    {
        var speaker = new Speaker { Employer = employer };

        var result = _rule.IsQualified(speaker);

        Assert.Equal(expected, result);
    }
}
