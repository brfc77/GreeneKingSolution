using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class EmailDomainRule : IQualificationRule
    {
        private static readonly HashSet<string> DisallowedDomains =
            new() { "aol.com", "prodigy.com", "compuserve.com" };

        public bool IsQualified(Speaker speaker)
        {
            var domain = speaker?.Email?.Split('@').Last();
            return !string.IsNullOrEmpty(domain) && !DisallowedDomains.Contains(domain);
        }
    }
}