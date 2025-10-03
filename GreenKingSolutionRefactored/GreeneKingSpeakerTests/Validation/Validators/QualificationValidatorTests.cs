using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Validators;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeakerTests.Validation.Validators
{
    public class QualificationValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnError_WhenNoRulesPassed()
        {
            var rules = new List<IQualificationRule>
            {
                new FakeRule(false),
                new FakeRule(false)
            };
            var validator = new QualificationValidator(rules);
            var speaker = new Speaker();

            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Contains(RegisterError.SpeakerDoesNotMeetStandards, result);
        }

        [Fact]
        public void Validate_ShouldReturnNull_WhenAtLeastOneRulePasses()
        {
            var rules = new List<IQualificationRule>
            {
                new FakeRule(false),
                new FakeRule(true),  // one rule passes
                new FakeRule(false)
            };
            var validator = new QualificationValidator(rules);
            var speaker = new Speaker();

            var result = validator.Validate(speaker);

            Assert.Null(result);
        }

        [Fact]
        public void Validate_ShouldReturnError_WhenRulesListIsEmpty()
        {
            var rules = new List<IQualificationRule>();
            var validator = new QualificationValidator(rules);
            var speaker = new Speaker();
            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Contains(RegisterError.SpeakerDoesNotMeetStandards, result);
        }

        private class FakeRule : IQualificationRule
        {
            private readonly bool _result;
            public FakeRule(bool result) => _result = result;
            public bool IsQualified(Speaker speaker) => _result;
        }
    }
}