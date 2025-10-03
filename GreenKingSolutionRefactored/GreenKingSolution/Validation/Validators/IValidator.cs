using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Validators
{
    public interface IValidator
    {
        List<RegisterError>? Validate(Speaker speaker);
    }
}
