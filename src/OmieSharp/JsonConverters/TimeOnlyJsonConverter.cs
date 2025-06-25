using System.Text.Json.Serialization;
using System.Text.Json;

namespace OmieSharp.JsonConverters;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return TimeOnly.FromDateTime(DateTime.ParseExact(value!, "HH:mm:ss", null));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeOnly value,
        JsonSerializerOptions options) =>
            writer.WriteStringValue(value!.ToString("HH:mm:ss"));
}
