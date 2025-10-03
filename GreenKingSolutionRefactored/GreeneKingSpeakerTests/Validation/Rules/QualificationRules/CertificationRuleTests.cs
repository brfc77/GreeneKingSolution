using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules;

public class CertificationRuleTests
{
    private readonly CertificationRule _rule = new();

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(3, false)]
    [InlineData(4, true)]
    [InlineData(10, true)]
    [InlineData(100, true)]
    public void IsQualified_ShouldReturnExpectedResult(int certificationCount, bool expected)
    {
        var speaker = new Speaker
        {
            Certifications = Enumerable.Range(1, certificationCount)
                                       .Select(i => $"Cert{i}")
                                       .ToList()
        };

        var result = _rule.IsQualified(speaker);

        Assert.Equal(expected, result);
    }
}