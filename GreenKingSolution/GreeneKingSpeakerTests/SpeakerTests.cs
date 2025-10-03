using Xunit;
using GreenKingSolution;

namespace GreenKingSpeakerTests;
public class SpeakerTests
{
    private Speaker CreateValidSpeaker()
    {
        return new Speaker
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            Exp = 5,
            HasBlog = true,
            BlogURL = "http://johndoe.com",
            Browser = new WebBrowser { Name = WebBrowser.BrowserName.Chrome, MajorVersion = 100 },
            Certifications = new List<string> { "MCP", "AWS" },
            Employer = "Google",
            Sessions = new List<Session>
            {
                new Session { Title = "Modern C#", Description = "Cool features", Approved = false }
            }
        };
    }

    [Fact]
    public void Register_ShouldReturnError_WhenFirstNameMissing()
    {
        var speaker = CreateValidSpeaker();
        speaker.FirstName = null;

        var response = speaker.Register(new UserRepository(), null, null, null, 0, false, null, null, null, null, 0, null);

        Assert.Equal(RegisterError.FirstNameRequired, response.RegisterError);
    }

    [Fact]
    public void Register_ShouldReturnError_WhenLastNameMissing()
    {
        var speaker = CreateValidSpeaker();
        speaker.LastName = "";

        var response = speaker.Register(new UserRepository(), null, null, null, 0, false, null, null, null, null, 0, null);

        Assert.Equal(RegisterError.LastNameRequired, response.RegisterError);
    }

    [Fact]
    public void Register_ShouldReturnError_WhenEmailMissing()
    {
        var speaker = CreateValidSpeaker();
        speaker.Email = "";

        var response = speaker.Register(new UserRepository(), null, null, null, 0, false, null, null, null, null, 0, null);

        Assert.Equal(RegisterError.EmailRequired, response.RegisterError);
    }

    [Fact]
    public void Register_ShouldReturnError_WhenNoSessions()
    {
        var speaker = CreateValidSpeaker();
        speaker.Sessions.Clear();

        var response = speaker.Register(new UserRepository(), null, null, speaker.Email, 0, false, null, null, null, null, 0, null);

        Assert.Equal(RegisterError.NoSessionsProvided, response.RegisterError);
    }

    [Fact]
    public void Register_ShouldReturnError_WhenSessionContainsOutdatedTech()
    {
        var speaker = CreateValidSpeaker();
        speaker.Sessions = new List<Session>
        {
            new Session { Title = "Cobol Basics", Description = "Old stuff", Approved = false }
        };

        var response = speaker.Register(new UserRepository(), null, null, speaker.Email, 0, false, null, null, null, null, 0, null);

        Assert.Equal(RegisterError.NoSessionsApproved, response.RegisterError);
    }

    [Fact]
    public void Register_ShouldSucceed_ForValidSpeaker()
    {
        var speaker = CreateValidSpeaker();

        var response = speaker.Register(new UserRepository(), null, null, speaker.Email, 0, false, null, null, null, null, 0, null);

        Assert.True(response.SpeakerId > 0);
        //Assert.Null(response.RegisterError);
    }
}