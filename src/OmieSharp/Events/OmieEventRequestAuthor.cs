using System.Text.Json.Serialization;

namespace OmieSharp.Events;

public class OmieEventRequestAuthor
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("userId")]
    public long UserId { get; set; }

    public OmieEventRequestAuthor(string email, string name, long userId)
    {
        Email = email;
        Name = name;
        UserId = userId;
    }
}
