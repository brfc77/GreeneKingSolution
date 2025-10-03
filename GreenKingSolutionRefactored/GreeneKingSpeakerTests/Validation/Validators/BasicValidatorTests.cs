using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Validators;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;

namespace GreeneKingSpeakerTests.Validation.Validators
{
    public class BasicValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnNull_WhenNoRulesProduceErrors()
        {
            var rules = new List<IValidationRule>
            {
                new FakeRule(null),
                new FakeRule(null)
            };
            var validator = new BasicValidator(rules);
            var speaker = new Speaker();
            var result = validator.Validate(speaker);

            Assert.Null(result);
        }

        [Fact]
        public void Validate_ShouldReturnSingleError_WhenOneRuleFails()
        {
            var rules = new List<IValidationRule>
            {
                new FakeRule(RegisterError.FirstNameRequired),
                new FakeRule(null)
            };
            var validator = new BasicValidator(rules);
            var speaker = new Speaker();
            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Contains(RegisterError.FirstNameRequired, result);
        }

        [Fact]
        public void Validate_ShouldReturnMultipleErrors_WhenMultipleRulesFail()
        {
            var rules = new List<IValidationRule>
            {
                new FakeRule(RegisterError.FirstNameRequired),
                new FakeRule(RegisterError.LastNameRequired),
                new FakeRule(null)
            };
            var validator = new BasicValidator(rules);
            var speaker = new Speaker();

            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(RegisterError.FirstNameRequired, result);
            Assert.Contains(RegisterError.LastNameRequired, result);
        }

        private class FakeRule : IValidationRule
        {
            private readonly RegisterError? _error;
            public FakeRule(RegisterError? error) => _error = error;
            public RegisterError? Check(Speaker speaker) => _error;
        }
    }
}