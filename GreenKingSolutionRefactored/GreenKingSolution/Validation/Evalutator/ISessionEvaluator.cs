using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;

namespace GreeneKingSpeaker.Validation.Evalutator
{
    public interface ISessionEvaluator
    {
        bool Evaluate(Session session);
    }
}