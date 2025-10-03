using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class CertificationRule : IQualificationRule
    {
        public bool IsQualified(Speaker speaker) => speaker.Certifications.Count > 3;
    }
}