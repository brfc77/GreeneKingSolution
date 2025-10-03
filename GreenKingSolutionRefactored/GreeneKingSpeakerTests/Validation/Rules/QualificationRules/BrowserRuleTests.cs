using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Models;
using Xunit;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules
{
    public class BrowserRuleTests
    {
        private readonly Speaker _speaker = new();
        private readonly BrowserRule _browserRule = new();

        [Fact]
        public void IsQualified_ShouldReturnFalse_WhenBrowserIsIEAndVersionIsLessThan9()
        {
            _speaker.Browser = new WebBrowser
            {
                Name = BrowserName.InternetExplorer,
                MajorVersion = 8
            };

            var result = _browserRule.IsQualified(_speaker);

            Assert.False(result);
        }

        [Fact]
        public void IsQualified_ShouldReturnTrue_WhenBrowserIsIEAndVersionIs9OrAbove()
        {
            _speaker.Browser = new WebBrowser
            {
                Name = BrowserName.InternetExplorer,
                MajorVersion = 9
            };

            var result = _browserRule.IsQualified(_speaker);

            Assert.True(result);
        }

        [Fact]
        public void IsQualified_ShouldReturnTrue_WhenBrowserIsNotIE()
        {
            _speaker.Browser = new WebBrowser
            {
                Name = BrowserName.Chrome,
                MajorVersion = 1
            };

            var result = _browserRule.IsQualified(_speaker);

            Assert.True(result);
        }

        [Fact]
        public void IsQualified_ShouldReturnTrue_WhenBrowserIsNull()
        {
            _speaker.Browser = null;

            var result = _browserRule.IsQualified(_speaker);

            Assert.True(result);
        }
    }

}