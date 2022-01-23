using System.Text.Json;
using System.Text.Json.Serialization;

namespace Windowee.Settings;

public class MarginConverter : JsonConverter<Margin>
{
    public override Margin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Margin.Parse(reader.GetString() ?? string.Empty);

    public override void Write(Utf8JsonWriter writer, Margin margin, JsonSerializerOptions options) =>
        writer.WriteStringValue(margin.ToString());
}