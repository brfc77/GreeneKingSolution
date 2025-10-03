using Xunit;
using Moq;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Validators;
using GreeneKingSpeaker.Validation;

namespace GreeneKingSpeakerTests.Validation
{
    public class SpeakerCheckerTests
    {
        [Fact]
        public void Validate_ShouldReturnNull_WhenAllValidatorsPass()
        {
            var mockValidator1 = new Mock<IValidator>();
            mockValidator1.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns((List<RegisterError>?)null);

            var mockValidator2 = new Mock<IValidator>();
            mockValidator2.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns((List<RegisterError>?)null);

            var checker = new SpeakerChecker(new[] { mockValidator1.Object, mockValidator2.Object });
            var speaker = new Speaker();

            var result = checker.Validate(speaker);

            Assert.Null(result);
            mockValidator1.Verify(v => v.Validate(speaker), Times.Once);
            mockValidator2.Verify(v => v.Validate(speaker), Times.Once);
        }

        [Fact]
        public void Validate_ShouldReturnErrors_WhenSingleValidatorFails()
        {
            var mockValidator1 = new Mock<IValidator>();
            mockValidator1.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns(new List<RegisterError> { RegisterError.FirstNameRequired });

            var mockValidator2 = new Mock<IValidator>();
            mockValidator2.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns((List<RegisterError>?)null);

            var checker = new SpeakerChecker(new[] { mockValidator1.Object, mockValidator2.Object });
            var speaker = new Speaker();

            var result = checker.Validate(speaker);

            Assert.NotNull(result);
            Assert.Contains(RegisterError.FirstNameRequired, result.RegisterError);
            mockValidator1.Verify(v => v.Validate(speaker), Times.Once);
            mockValidator2.Verify(v => v.Validate(speaker), Times.Once);
        }

        [Fact]
        public void Validate_ShouldAggregateErrors_FromMultipleValidators()
        {
            var mockValidator1 = new Mock<IValidator>();
            mockValidator1.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns(new List<RegisterError> { RegisterError.FirstNameRequired });

            var mockValidator2 = new Mock<IValidator>();
            mockValidator2.Setup(v => v.Validate(It.IsAny<Speaker>()))
                          .Returns(new List<RegisterError> { RegisterError.LastNameRequired });

            var checker = new SpeakerChecker(new[] { mockValidator1.Object, mockValidator2.Object });
            var speaker = new Speaker();

            var result = checker.Validate(speaker);

            Assert.NotNull(result);
            Assert.Equal(2, result.RegisterError.Count);
            Assert.Contains(RegisterError.FirstNameRequired, result.RegisterError);
            Assert.Contains(RegisterError.LastNameRequired, result.RegisterError);
            mockValidator1.Verify(v => v.Validate(speaker), Times.Once);
            mockValidator2.Verify(v => v.Validate(speaker), Times.Once);
        }
    }
}