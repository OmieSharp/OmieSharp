using System.Text.Json.Serialization;

namespace OmieSharp.Events;

public class OmieEventRequest<T>
{
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    [JsonPropertyName("topic")]
    public string Topic { get; set; }

    [JsonPropertyName("event")]
    public T Event { get; set; }

    [JsonPropertyName("author")]
    public OmieEventRequestAuthor Author { get; set; }

    [JsonPropertyName("appKey")]
    public string AppKey { get; set; }

    [JsonPropertyName("appHash")]
    public string AppHash { get; set; }

    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    public OmieEventRequest(string messageId, string topic, T @event, OmieEventRequestAuthor author, string appKey, string appHash, string origin)
    {
        MessageId = messageId;
        Topic = topic;
        Event = @event;
        Author = author;
        AppKey = appKey;
        AppHash = appHash;
        Origin = origin;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(AppKey))
            throw new ArgumentNullException(nameof(AppKey));
        if (Event == null)
            throw new ArgumentException(nameof(Event));
    }
}
