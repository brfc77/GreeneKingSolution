using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Validators;

namespace GreeneKingSpeaker.Validation
{
    public class SpeakerChecker : ISpeakerChecker
    {
        private readonly IEnumerable<IValidator> _validators;

        public SpeakerChecker(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public RegisterResponse? Validate(Speaker speaker)
        {
            var results = new List<RegisterError>();
            foreach (var validator in _validators)
            {
                /* The original code navigated through each elected versions of validation one by one
                 * so if first name was invalid and so was last name you'd only know that at the point
                 * that you re-corrected firstname that last name was incorrect. This way all validation
                 * issues are given up front rather than one at a time, unsure if that works with the program
                 * this comes from but makes more sense to me to do it this way.
                 * This could easily be reworked to instead if "basic validation" then "qualification" then "sessions"
                 * need to be checked in order by adding a OrderNumber value to those that use IValidator and
                 * ordering the validators in that order that they need to run and breaking if any validation errors
                 * occur before hitting the next validator
                 */
                var result = validator.Validate(speaker);
                if(result != null)
                {
                    results.AddRange(result);
                }
            }

            if (results.Count != 0)
            {
                return new RegisterResponse(results);
            }

            return null;
        }
    }
}