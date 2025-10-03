using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Evalutator;
using GreeneKingSpeaker.Validation.Rules.SessionRules;

namespace GreeneKingSpeaker.Validation.Validators
{
    public class SessionValidator : IValidator
    {
        private readonly ISessionEvaluator _sessionEvaluator;

        public SessionValidator(ISessionEvaluator sessionEvaluator)
        {
            _sessionEvaluator = sessionEvaluator;
        }

        public List<RegisterError>? Validate(Speaker speaker)
        {
            if (speaker.Sessions == null || !speaker.Sessions.Any())
            {
                return [RegisterError.NoSessionsProvided];
            }

            foreach (var session in speaker.Sessions)
            {
                var approved = _sessionEvaluator.Evaluate(session);
                session.SetApproval(approved);
            }

            return speaker.Sessions.Any(s => s.Approved)
                ? null
                : [RegisterError.NoSessionsApproved];
        }
    }
}