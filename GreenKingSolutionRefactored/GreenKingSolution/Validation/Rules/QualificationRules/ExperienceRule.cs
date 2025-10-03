using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class ExperienceRule : IQualificationRule
    {
        public bool IsQualified(Speaker speaker) => speaker.ExperienceYears > 10;
    }
}