using System.Text.Json;
using System.Text.Json.Serialization;

namespace OmieSharp.JsonConverters;

public class EmptyToNullStringJsonConverter : JsonConverter<string?>
{
    public override string? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
            ParseEmptyString(reader.GetString());

    public override void Write(
        Utf8JsonWriter writer,
        string? value,
        JsonSerializerOptions options) =>
            writer.WriteStringValue(value);

    private static String? ParseEmptyString(String? value)
    {
        if (string.IsNullOrEmpty(value))
            return null;

        return value;
    }
}
