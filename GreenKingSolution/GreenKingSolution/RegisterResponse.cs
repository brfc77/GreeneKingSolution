namespace GreenKingSolution
{
    public class RegisterResponse
    {
        public RegisterError RegisterError { get; set; }
        public int SpeakerId { get; set; }
        public RegisterResponse(RegisterError registerError)
        { RegisterError = registerError; }

        public RegisterResponse(int speakerid)
        { SpeakerId = speakerid; }
    }
}
