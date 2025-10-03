using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation
{
    public interface ISpeakerChecker
    {
        RegisterResponse? Validate(Speaker speaker);
    }
}