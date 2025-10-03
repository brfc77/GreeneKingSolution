using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker
{
    public interface ISpeakerRegister
    {
        RegisterResponse Register(Speaker speaker);
    }
}
