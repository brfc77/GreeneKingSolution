using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;
using Xunit;

namespace GreeneKingSpeakerTests.Validation.Rules.SessionRules
{
    public class SufficientDescriptionRuleTests
    {
        private readonly SufficientDescriptionRule _rule = new();

        [Fact]
        public void IsValid_WhenDescriptionIsLongEnough_ReturnsTrue()
        {
            var session = new Session
            {
                Title = "Short",
                Description = new string('a', 50) // exactly 50 chars
            };

            var result = _rule.IsValid(session);

            Assert.True(result);
        }

        [Fact]
        public void IsValid_WhenTitleIsLongEnough_ReturnsTrue()
        {
            var session = new Session
            {
                Title = new string('b', 30), // exactly 30 chars
                Description = "Tiny"
            };

            var result = _rule.IsValid(session);

            Assert.True(result);
        }

        [Fact]
        public void IsValid_WhenTitleAndDescriptionTooShort_ReturnsFalse()
        {
            var session = new Session
            {
                Title = "Short",
                Description = "Not long enough"
            };

            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WhenBothNull_ReturnsFalse()
        {
            var session = new Session { Title = null, Description = null };

            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Theory]
        [InlineData(29, 49)] // just under both thresholds
        [InlineData(10, 10)] // way under both thresholds
        public void IsValid_WhenUnderThresholds_ReturnsFalse(int titleLength, int descriptionLength)
        {
            var session = new Session
            {
                Title = new string('t', titleLength),
                Description = new string('d', descriptionLength)
            };

            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Theory]
        [InlineData(30, 0)] // exactly threshold for title
        [InlineData(0, 50)] // exactly threshold for description
        [InlineData(31, 49)] // over title threshold even if desc is short
        [InlineData(10, 60)] // over description threshold even if title is short
        public void IsValid_WhenMeetsEitherThreshold_ReturnsTrue(int titleLength, int descriptionLength)
        {
            var session = new Session
            {
                Title = new string('t', titleLength),
                Description = new string('d', descriptionLength)
            };

            var result = _rule.IsValid(session);

            Assert.True(result);
        }
    }
}