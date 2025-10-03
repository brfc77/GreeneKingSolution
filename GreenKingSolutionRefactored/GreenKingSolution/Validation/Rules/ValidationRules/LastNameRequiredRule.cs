using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Rules.ValidationRules
{
    public class LastNameRequiredRule : IValidationRule
    {
        public RegisterError? Check(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.LastName))
                return RegisterError.LastNameRequired;

            return null;
        }
    }
}