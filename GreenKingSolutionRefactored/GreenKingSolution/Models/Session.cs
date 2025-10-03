namespace GreeneKingSpeaker.Models
{
    //Assumed model class based on original speaker.register code
    public class Session
    {
        public bool Approved { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public void SetApproval(bool approved)
        {
            Approved = approved;
        }
    }
}