using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;
using Xunit;

namespace GreeneKingSpeakerTests.Validation.Rules.SessionRules
{
    public class OutdatedTechnologyRuleTests
    {
        private readonly OutdatedTechnologyRule _rule = new();

        [Fact]
        public void IsValid_WhenTitleContainsOutdatedTech_ReturnsFalse()
        {
            var session = new Session { Title = "Cobol Basics", Description = "Intro to legacy systems" };

            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WhenDescriptionContainsOutdatedTech_ReturnsFalse()
        {
            var session = new Session { Title = "Modern Systems", Description = "Migrating from VBScript" };
            
            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WhenBothTitleAndDescriptionClean_ReturnsTrue()
        {
            var session = new Session { Title = "Modern .NET", Description = "Intro to C# 12 and ASP.NET Core" };

            var result = _rule.IsValid(session);

            Assert.True(result);
        }

        [Theory]
        [InlineData("cobol")]
        [InlineData("PUNCH CARDS")]
        [InlineData("commodore")]
        [InlineData("vbscript")]
        public void IsValid_WhenCaseInsensitiveMatchFound_ReturnsFalse(string tech)
        {
            var session = new Session { Title = $"Learning {tech}", Description = "" };
            
            var result = _rule.IsValid(session);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WhenSessionIsNullProperties_TreatsAsEmptyAndReturnsTrue()
        {
            var session = new Session { Title = null, Description = null };

            var result = _rule.IsValid(session);

            Assert.True(result);
        }
    }
}