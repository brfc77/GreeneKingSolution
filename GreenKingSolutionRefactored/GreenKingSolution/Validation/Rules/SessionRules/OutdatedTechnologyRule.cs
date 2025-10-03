using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.SessionRules
{
    public class OutdatedTechnologyRule : ISessionRule
    {
        // Technologies we consider outdated/rejected?
        private static readonly List<string> OutdatedTechnologies =
            new() { "Cobol", "Punch Cards", "Commodore", "VBScript" };

        public bool IsValid(Session session)
        {
            var title = session.Title ?? "";
            var description = session.Description ?? "";

            return !OutdatedTechnologies.Any(tech =>
                title.Contains(tech, StringComparison.OrdinalIgnoreCase) ||
                description.Contains(tech, StringComparison.OrdinalIgnoreCase));
        }
    }
}