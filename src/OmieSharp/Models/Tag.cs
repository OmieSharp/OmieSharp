using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Tag
{
    [JsonPropertyName("tag")]
    public string TagValue { get; set; }

    public Tag()
    {
        this.TagValue = "";
    }

    public Tag(string tag)
    {
        this.TagValue = tag;
    }
}
