using GreeneKingSpeaker.Models;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class BlogRule : IQualificationRule
    {
        public bool IsQualified(Speaker speaker) => speaker.HasBlog;
    }
}