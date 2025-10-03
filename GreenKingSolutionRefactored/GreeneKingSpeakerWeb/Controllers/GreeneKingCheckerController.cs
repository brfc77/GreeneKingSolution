using GreeneKingSpeaker;
using GreeneKingSpeaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreeneKingSpeakerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreeneKingCheckerController : ControllerBase
    {
        private readonly ISpeakerRegister _speakerRegister;

        public GreeneKingCheckerController(ISpeakerRegister speakerRegister)
        {
            _speakerRegister = speakerRegister;
        }

        /* Wouldn't normally just pass a domain object to a controller. This is just for testing purposes */
        [HttpPost]
        public RegisterResponse RegisterSpeaker(Speaker speaker)
        {
            return _speakerRegister.Register(speaker);
        }
    }
}
