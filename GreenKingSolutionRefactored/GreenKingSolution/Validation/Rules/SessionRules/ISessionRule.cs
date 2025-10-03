using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.SessionRules
{
    public interface ISessionRule
    {
        bool IsValid(Session session);
    }
}