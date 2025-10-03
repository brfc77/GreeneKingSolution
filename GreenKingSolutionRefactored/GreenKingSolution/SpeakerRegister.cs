using GreeneKingSpeaker.Calculators;
using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Repository;
using GreeneKingSpeaker.Validation;

namespace GreeneKingSpeaker
{
    public class SpeakerRegister : ISpeakerRegister
    {
        private readonly ISpeakerChecker _speakerChecker;
        private readonly IFeeCalculator _feeCalculator;
        private readonly ISpeakerRegisterRepository _repository;

        public SpeakerRegister(
            ISpeakerChecker speakerChecker,
            IFeeCalculator feeCalculator,
            ISpeakerRegisterRepository repository)
        {
            _speakerChecker = speakerChecker;
            _feeCalculator = feeCalculator;
            _repository = repository;
        }

        public RegisterResponse Register(Speaker speaker)
        {
            var validationResult = _speakerChecker.Validate(speaker);
            if (validationResult != null)
                return validationResult;

            var fee = _feeCalculator.CalculateFee(speaker.ExperienceYears);
            speaker.AssignFee(fee);

            return TrySaveSpeaker(speaker);
        }

        private RegisterResponse TrySaveSpeaker(Speaker speaker)
        {
            try
            {
                var speakerId = _repository.SaveSpeaker(speaker);
                return new RegisterResponse(speakerId);
            }
            catch
            {
                // log exception in normal circumstances
                return new RegisterResponse(RegisterError.SaveError);
            }
        }
    }
}
