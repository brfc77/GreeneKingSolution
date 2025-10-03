using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Rules.ValidationRules
{
    public class EmailRequiredRule : IValidationRule
    {
        public RegisterError? Check(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.Email)) // Null or white space seemed better than checking if not null or count not equal to 0
                return RegisterError.EmailRequired;

            return null;
        }
    }
}