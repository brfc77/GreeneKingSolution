using Moq;
using Xunit;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Validators;
using GreeneKingSpeaker.Validation.Evalutator;

namespace GreeneKingSpeakerTests
{
    public class SessionValidatorTests
    {
        [Fact]
        public void Validate_NoSessionsProvided_ReturnsNoSessionsProvidedError()
        {
            var speaker = new Speaker { Sessions = new List<Session>() };
            var evaluatorMock = new Mock<ISessionEvaluator>();

            var validator = new SessionValidator(evaluatorMock.Object);

            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Contains(RegisterError.NoSessionsProvided, result);
        }

        [Fact]
        public void Validate_AllSessionsApproved_ReturnsNull()
        {
            var sessions = new List<Session>
            {
                new Session { Title = "Session 1" },
                new Session { Title = "Session 2" }
            };

            var speaker = new Speaker { Sessions = sessions };

            var evaluatorMock = new Mock<ISessionEvaluator>();
            evaluatorMock.Setup(e => e.Evaluate(It.IsAny<Session>())).Returns(true);

            var validator = new SessionValidator(evaluatorMock.Object);

            var result = validator.Validate(speaker);

            Assert.Null(result); // success means no errors
            Assert.All(sessions, s => Assert.True(s.Approved));
        }

        [Fact]
        public void Validate_AllSessionsRejected_ReturnsNoSessionsApprovedError()
        {
            var sessions = new List<Session>
            {
                new Session { Title = "Bad Talk" },
                new Session { Title = "Another Bad Talk" }
            };

            var speaker = new Speaker { Sessions = sessions };

            var evaluatorMock = new Mock<ISessionEvaluator>();
            evaluatorMock.Setup(e => e.Evaluate(It.IsAny<Session>())).Returns(false);

            var validator = new SessionValidator(evaluatorMock.Object);

            var result = validator.Validate(speaker);

            Assert.NotNull(result);
            Assert.Contains(RegisterError.NoSessionsApproved, result);
            Assert.All(sessions, s => Assert.False(s.Approved));
        }

        [Fact]
        public void Validate_MixedSessionApprovals_ReturnsNull()
        {
            var sessions = new List<Session>
            {
                new Session { Title = "Good Talk" },
                new Session { Title = "Bad Talk" }
            };

            var speaker = new Speaker { Sessions = sessions };

            var evaluatorMock = new Mock<ISessionEvaluator>();
            evaluatorMock.SetupSequence(e => e.Evaluate(It.IsAny<Session>()))
                         .Returns(true)  // first session approved
                         .Returns(false); // second rejected

            var validator = new SessionValidator(evaluatorMock.Object);

            var result = validator.Validate(speaker);

            Assert.Null(result); // at least one approved -> no error
            Assert.True(sessions.First().Approved);
            Assert.False(sessions.Last().Approved);
        }
    }
}
