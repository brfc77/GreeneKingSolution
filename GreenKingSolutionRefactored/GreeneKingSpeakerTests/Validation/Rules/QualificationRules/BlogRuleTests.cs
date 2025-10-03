using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;
using Xunit;

namespace GreeneKingSpeakerTests.Validation.Rules.QualificationRules
{
    public class BlogRuleTests
    {
        private readonly Speaker _speaker = new();
        private readonly BlogRule _blogRule = new();

        [Fact]
        public void IfBlogRuleIsTrue_ReturnTrue()
        {
            _speaker.HasBlog = true;
            var result = _blogRule.IsQualified(_speaker);

            Assert.True(result);
        }

        [Fact]
        public void IfBlogRuleIsFalse_ReturnFalse()
        {
            _speaker.HasBlog = false;
            var result = _blogRule.IsQualified(_speaker);

            Assert.False(result);
        }
    }
}