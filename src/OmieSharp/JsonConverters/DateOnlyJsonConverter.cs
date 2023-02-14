using System.Text.Json.Serialization;
using System.Text.Json;

namespace OmieSharp.JsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == null)
                return null;
            return DateOnly.FromDateTime(DateTime.ParseExact(value, "dd/MM/yyyy", null));
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateOnly? value,
            JsonSerializerOptions options) =>
                writer.WriteStringValue((value.HasValue ? value!.Value.ToString("dd/MM/yyyy") : null));
    }
}
