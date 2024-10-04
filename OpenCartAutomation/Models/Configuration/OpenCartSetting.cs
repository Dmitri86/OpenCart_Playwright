namespace OpenCartAutomation.Models.Configuration;

public class OpenCartSetting
{
    public string Url { get; set; }

    public UserModel UserCredential { get; set; } = new();
}