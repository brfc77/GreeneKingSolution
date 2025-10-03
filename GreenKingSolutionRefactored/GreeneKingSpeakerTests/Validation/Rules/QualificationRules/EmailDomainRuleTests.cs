using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules;

public class EmailDomainRuleTests
{
    private readonly EmailDomainRule _rule = new();

    [Theory]
    [InlineData("test@gmail.com", true)]        // allowed domain
    [InlineData("someone@yahoo.com", true)]     // allowed domain
    [InlineData("user@aol.com", false)]         // disallowed
    [InlineData("person@prodigy.com", false)]   // disallowed
    [InlineData("old@compuserve.com", false)]   // disallowed
    [InlineData("invalidEmail", true)]          // no domain part - unsure if the code here should be checking there is an actual domain before the check occurs
    [InlineData("", false)]                     // empty email
    public void IsQualified_ShouldReturnExpected(string email, bool expected)
    {
        var speaker = new Speaker { Email = email };

        var result = _rule.IsQualified(speaker);

        Assert.Equal(expected, result);
    }
}
