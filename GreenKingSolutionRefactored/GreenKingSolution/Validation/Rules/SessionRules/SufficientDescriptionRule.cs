using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.SessionRules
{
    public class SufficientDescriptionRule : ISessionRule
    {
        public bool IsValid(Session session) =>
            (session.Description?.Length ?? 0) >= 50 ||
            (session.Title?.Length ?? 0) >= 30;
    }
}