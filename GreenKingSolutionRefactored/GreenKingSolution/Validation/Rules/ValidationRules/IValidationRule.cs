using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Rules.ValidationRules
{
    public interface IValidationRule
    {
        RegisterError? Check(Speaker speaker);
    }
}