using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class EmployerRule : IQualificationRule
    {
        private static readonly HashSet<string> PreferredEmployers =
            new() { "Pluralsight", "Microsoft", "Google" };

        public bool IsQualified(Speaker speaker) => PreferredEmployers.Contains(speaker.Employer);
    }
}