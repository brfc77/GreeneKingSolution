using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public interface IQualificationRule
    {
        bool IsQualified(Speaker speaker);
    }
}