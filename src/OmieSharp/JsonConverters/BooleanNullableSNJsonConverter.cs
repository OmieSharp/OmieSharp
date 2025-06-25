using System.Text.Json.Serialization;
using System.Text.Json;

namespace OmieSharp.JsonConverters;

public class BooleanNullableSNJsonConverter : JsonConverter<bool?>
{
    public override bool? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
            reader.GetString()?.Equals("S") ?? null;

    public override void Write(
        Utf8JsonWriter writer,
        bool? value,
        JsonSerializerOptions options) =>
            writer.WriteStringValue((value.HasValue ? (value == true ? "S" : "N") : null));
}
