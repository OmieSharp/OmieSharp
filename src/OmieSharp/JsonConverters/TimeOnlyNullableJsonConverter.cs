using System.Text.Json.Serialization;
using System.Text.Json;

namespace OmieSharp.JsonConverters;

public class TimeOnlyNullableJsonConverter : JsonConverter<TimeOnly?>
{
    public override TimeOnly? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
            return null;
        return TimeOnly.FromDateTime(DateTime.ParseExact(value, "HH:mm:ss", null));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeOnly? value,
        JsonSerializerOptions options) =>
            writer.WriteStringValue((value.HasValue ? value!.Value.ToString("HH:mm:ss") : null));
}
