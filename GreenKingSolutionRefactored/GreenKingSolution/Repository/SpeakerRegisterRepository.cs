using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Repository
{
    public class SpeakerRegisterRepository : ISpeakerRegisterRepository
    {
        /* Unsure what the original IRepository did so just made this return a
         * number for testing purposes */
        public SpeakerRegisterRepository() { }

        public int SaveSpeaker(Speaker speaker)
        {
            return 42;
        }
    }
}