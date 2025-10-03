using Moq;
using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;
using GreeneKingSpeaker.Validation.Evalutator;

namespace GreeneKingSpeakerTests
{
    public class SessionEvaluatorTests
    {
        [Fact]
        public void Evaluate_AllRulesPass_ReturnsTrue()
        {
            var session = new Session { Title = "Clean Code", Description = "A talk about SOLID principles" };

            var rule1 = new Mock<ISessionRule>();
            rule1.Setup(r => r.IsValid(session)).Returns(true);

            var rule2 = new Mock<ISessionRule>();
            rule2.Setup(r => r.IsValid(session)).Returns(true);

            var evaluator = new SessionEvaluator(new List<ISessionRule> { rule1.Object, rule2.Object });
            var result = evaluator.Evaluate(session);

            Assert.True(result);
        }

        [Fact]
        public void Evaluate_OneRuleFails_ReturnsFalse()
        {
            var session = new Session { Title = "Bad Talk", Description = "Not useful" };

            var passingRule = new Mock<ISessionRule>();
            passingRule.Setup(r => r.IsValid(session)).Returns(true);

            var failingRule = new Mock<ISessionRule>();
            failingRule.Setup(r => r.IsValid(session)).Returns(false);

            var evaluator = new SessionEvaluator(new List<ISessionRule> { passingRule.Object, failingRule.Object });

            var result = evaluator.Evaluate(session);

            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NoRules_ReturnsTrue()
        {
            var session = new Session { Title = "Edge Case", Description = "No rules provided" };
            var evaluator = new SessionEvaluator(new List<ISessionRule>()); // empty rules

            var result = evaluator.Evaluate(session);

            Assert.True(result); // With no rules, session should be considered valid
        }
    }
}
