using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Rules.ValidationRules
{
    public class FirstNameRequiredRule : IValidationRule
    {
        public RegisterError? Check(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.FirstName))
                return RegisterError.FirstNameRequired;

            return null;
        }
    }
}