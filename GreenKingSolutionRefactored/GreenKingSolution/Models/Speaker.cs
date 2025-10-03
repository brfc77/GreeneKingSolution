using GreeneKingSpeaker.Calculators;

namespace GreeneKingSpeaker.Models
{
    public class Speaker
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? ExperienceYears { get; set; } // Renamed from Exp?
        public bool HasBlog { get; set; }
        public string BlogURL { get; set; } = string.Empty; /* Is this needed if not used in the class? I assume used elsewhere */
        public WebBrowser? Browser { get; set; }
        public List<string> Certifications { get; set; } = new();
        public string Employer { get; set; } = string.Empty;
        public int RegistrationFee { get; set; } = 0;
        public List<Session> Sessions { get; set; } = new();

        public void AssignFee(int fee)
        {
            RegistrationFee = fee;
        }
    }
}