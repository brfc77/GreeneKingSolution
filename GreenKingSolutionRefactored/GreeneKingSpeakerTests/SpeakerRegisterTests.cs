using Xunit;
using Moq;
using GreeneKingSpeaker;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation;
using GreeneKingSpeaker.Calculators;
using GreeneKingSpeaker.Repository;

public class SpeakerRegisterTests
{
    [Fact]
    public void Register_ShouldReturnValidationResult_WhenValidationFails()
    {
        var mockChecker = new Mock<ISpeakerChecker>();
        var expectedResponse = new RegisterResponse(RegisterError.FirstNameRequired);
        mockChecker.Setup(c => c.Validate(It.IsAny<Speaker>()))
                   .Returns(expectedResponse);

        var mockFeeCalculator = new Mock<IFeeCalculator>();
        var mockRepository = new Mock<ISpeakerRegisterRepository>();

        var register = new SpeakerRegister(
            mockChecker.Object,
            mockFeeCalculator.Object,
            mockRepository.Object);

        var result = register.Register(new Speaker());

        Assert.Equal(expectedResponse.RegisterError, result.RegisterError);
        Assert.Null(result.SpeakerId);
        mockChecker.Verify(c => c.Validate(It.IsAny<Speaker>()), Times.Once);
        mockFeeCalculator.Verify(c => c.CalculateFee(It.IsAny<int?>()), Times.Never);
        mockRepository.Verify(r => r.SaveSpeaker(It.IsAny<Speaker>()), Times.Never);
    }

    [Fact]
    public void Register_ShouldCalculateFeeAndSave_WhenValidationPasses()
    {
        var mockChecker = new Mock<ISpeakerChecker>();
        mockChecker.Setup(c => c.Validate(It.IsAny<Speaker>()))
                   .Returns((RegisterResponse?)null);

        var mockFeeCalculator = new Mock<IFeeCalculator>();
        mockFeeCalculator.Setup(f => f.CalculateFee(It.IsAny<int?>()))
                         .Returns(123);

        var mockRepository = new Mock<ISpeakerRegisterRepository>();
        mockRepository.Setup(r => r.SaveSpeaker(It.IsAny<Speaker>()))
                      .Returns(42);

        var register = new SpeakerRegister(
            mockChecker.Object,
            mockFeeCalculator.Object,
            mockRepository.Object);

        var speaker = new Speaker { ExperienceYears = 5 };

        var result = register.Register(speaker);

        Assert.Equal(42, result.SpeakerId);
        Assert.Equal(123, speaker.RegistrationFee);

        mockChecker.Verify(c => c.Validate(speaker), Times.Once);
        mockFeeCalculator.Verify(f => f.CalculateFee(5), Times.Once);
        mockRepository.Verify(r => r.SaveSpeaker(speaker), Times.Once);
    }

    [Fact]
    public void Register_ShouldReturnSaveError_WhenRepositoryThrows()
    {
        var mockChecker = new Mock<ISpeakerChecker>();
        mockChecker.Setup(c => c.Validate(It.IsAny<Speaker>()))
                   .Returns((RegisterResponse?)null);

        var mockFeeCalculator = new Mock<IFeeCalculator>();
        mockFeeCalculator.Setup(f => f.CalculateFee(It.IsAny<int?>()))
                         .Returns(50);

        var mockRepository = new Mock<ISpeakerRegisterRepository>();
        mockRepository.Setup(r => r.SaveSpeaker(It.IsAny<Speaker>()))
                      .Throws(new System.Exception("DB failure"));

        var register = new SpeakerRegister(
            mockChecker.Object,
            mockFeeCalculator.Object,
            mockRepository.Object);

        var speaker = new Speaker { ExperienceYears = 2 };

        var result = register.Register(speaker);

        Assert.Contains(RegisterError.SaveError, result.RegisterError);

        mockChecker.Verify(c => c.Validate(speaker), Times.Once);
        mockFeeCalculator.Verify(f => f.CalculateFee(2), Times.Once);
        mockRepository.Verify(r => r.SaveSpeaker(speaker), Times.Once);
    }
}