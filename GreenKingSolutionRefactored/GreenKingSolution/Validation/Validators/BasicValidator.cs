using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;

namespace GreeneKingSpeaker.Validation.Validators
{
    public class BasicValidator : IValidator
    {
        private readonly IEnumerable<IValidationRule> _rules;

        public BasicValidator(IEnumerable<IValidationRule> rules)
        {
            _rules = rules;
        }

        /* This tries to replicate this logic 
         *             if (!((FirstName == null) || (FirstName.Length == 0)))
            {
                if (!((LastName == null) || (LastName.Length == 0)))
                {
                    if (!((Email == null) || (Email.Length == 0)))
        */
        public List<RegisterError>? Validate(Speaker speaker)
        {
            var registerErrors = new List<RegisterError>();
            foreach (var rule in _rules)
            {
                var error = rule.Check(speaker);
                if (error.HasValue)
                    registerErrors.Add(error.Value);
            }
            return registerErrors.Any() ? registerErrors : null; // Instead of returning null this could always return an object with isValid value of true/false
        }
    }
}
