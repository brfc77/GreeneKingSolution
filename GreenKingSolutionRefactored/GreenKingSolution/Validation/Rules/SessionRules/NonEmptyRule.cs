using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.SessionRules
{
    public class NonEmptyRule : ISessionRule
    {
        public bool IsValid(Session session) =>
            !(string.IsNullOrWhiteSpace(session.Title) && string.IsNullOrWhiteSpace(session.Description));
    }
}