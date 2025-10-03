using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;
using Xunit;

namespace GreeneKingSpeakerTests.Validation.Rules.SessionRules
{
    public class NonEmptyRuleTests
    {
        private readonly NonEmptyRule _rule = new();

        [Fact]
        public void IsValid_WhenTitleAndDescriptionEmpty_ReturnsFalse()
        {
            
            var session = new Session { Title = "", Description = "" };

            
            var result = _rule.IsValid(session);

            
            Assert.False(result);
        }

        [Fact]
        public void IsValid_WhenTitleIsPresent_ReturnsTrue()
        {
            
            var session = new Session { Title = "Test", Description = "" };

            
            var result = _rule.IsValid(session);

            
            Assert.True(result);
        }

        [Fact]
        public void IsValid_WhenDescriptionIsPresent_ReturnsTrue()
        {
            
            var session = new Session { Title = "", Description = "Some description" };

            
            var result = _rule.IsValid(session);

            
            Assert.True(result);
        }

        [Fact]
        public void IsValid_WhenBothPresent_ReturnsTrue()
        {
            
            var session = new Session { Title = "Test", Description = "Some description" };

            
            var result = _rule.IsValid(session);

            
            Assert.True(result);
        }
    }
}