using GreeneKingSpeaker.Models;
using GreeneKingSpeaker.Models.Enums;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;

namespace GreeneKingSpeaker.Validation.Validators
{
    public class QualificationValidator : IValidator
    {
        private readonly IEnumerable<IQualificationRule> _qualificationRules;

        public QualificationValidator(IEnumerable<IQualificationRule> qualificationRules)
        {
            _qualificationRules = qualificationRules;
        }

        /* This tries to replicate this behaviour
         * var emps = new List<string>() { "Pluralsight", "Microsoft", "Google" };

                        good = Exp > 10 || HasBlog || Certifications.Count() > 3 || emps.Contains(Employer);

                        if (!good)
                        {
                            //need to get just the domain from the email
                            string emailDomain = Email.Split('@').Last();

                            if (!domains.Contains(emailDomain) && (!(Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9)))
                            {
                                good = true;
                            }
                        }
        */
        public List<RegisterError>? Validate(Speaker speaker)
        {
            if (!_qualificationRules.Any(r => r.IsQualified(speaker)))
                return [RegisterError.SpeakerDoesNotMeetStandards];

            return null;
        }
    }
}
