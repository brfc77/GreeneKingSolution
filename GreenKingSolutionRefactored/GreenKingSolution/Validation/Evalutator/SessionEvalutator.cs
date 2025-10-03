using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Validation.Rules.SessionRules;

namespace GreeneKingSpeaker.Validation.Evalutator
{
    public class SessionEvaluator : ISessionEvaluator
    {
        private readonly IEnumerable<ISessionRule> _rules;
        public SessionEvaluator(IEnumerable<ISessionRule> rules)
        {
            _rules = rules;
        }

        public bool Evaluate(Session session)
        {
            foreach (var rule in _rules)
            {
                if (!rule.IsValid(session))
                    return false;
            }
            return true;
        }
    }
}