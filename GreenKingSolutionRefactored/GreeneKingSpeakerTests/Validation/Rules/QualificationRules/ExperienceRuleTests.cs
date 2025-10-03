using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules
{
    public class ExperienceRuleTests
    {
        private readonly ExperienceRule _rule = new();

        [Theory]
        [InlineData(0, false)]   // no experience
        [InlineData(5, false)]   // below threshold
        [InlineData(10, false)]  // exactly threshold
        [InlineData(11, true)]   // just above threshold
        [InlineData(20, true)]   // well above threshold
        [InlineData(null, false)] // null years of experience
        public void IsQualified_ShouldReturnExpected(int? years, bool expected)
        {
            var speaker = new Speaker { ExperienceYears = years };

            var result = _rule.IsQualified(speaker);

            Assert.Equal(expected, result);
        }
    }

}