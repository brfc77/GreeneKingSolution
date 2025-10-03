using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;

namespace GreeneKingSpeaker.Validation.Rules.QualificationRules
{
    public class BrowserRule : IQualificationRule
    {
        public bool IsQualified(Speaker speaker)
        {
            return !(speaker.Browser?.Name == BrowserName.InternetExplorer &&
                     speaker.Browser.MajorVersion < 9);
        }
    }
}