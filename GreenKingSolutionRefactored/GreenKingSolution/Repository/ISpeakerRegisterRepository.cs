using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Repository
{
    public interface ISpeakerRegisterRepository
    {
        int SaveSpeaker(Speaker speaker);
    }
}
