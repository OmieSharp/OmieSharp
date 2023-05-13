using System.Text.Json.Serialization;

namespace OmieSharp.Events
{
    public class OmieEventRequestMultiple<T>
    {
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        //Multiple request receive a list of Events
        [JsonPropertyName("event")]
        public List<T> Events { get; set; }

        [JsonPropertyName("author")]
        public OmieEventRequestAuthor Author { get; set; }

        [JsonPropertyName("appKey")]
        public string AppKey { get; set; }

        [JsonPropertyName("appHash")]
        public string AppHash { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        public OmieEventRequestMultiple(string messageId, string topic, List<T> events, OmieEventRequestAuthor author, string appKey, string appHash, string origin)
        {
            MessageId = messageId;
            Topic = topic;
            Events = events;
            Author = author;
            AppKey = appKey;
            AppHash = appHash;
            Origin = origin;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(AppKey))
                throw new ArgumentNullException(nameof(AppKey));
            if (Events == null)
                throw new ArgumentException(nameof(Events));
        }
    }
}
