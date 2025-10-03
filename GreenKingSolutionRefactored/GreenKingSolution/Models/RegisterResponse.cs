using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Models
{
    public class RegisterResponse
    {
        public List<RegisterError> RegisterError { get; set; } = new();
        public int? SpeakerId { get; set; }
        public RegisterResponse(List<RegisterError> registerError)
        { RegisterError = registerError; }
        public RegisterResponse(RegisterError registerError)
        { RegisterError = new List<RegisterError> { registerError }; }
        public RegisterResponse(int speakerid)
        { SpeakerId = speakerid; }
    }
}