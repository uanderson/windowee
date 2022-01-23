using System.Text.Json;
using System.Text.Json.Serialization;

namespace Windowee.Settings;

public class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (!string.IsNullOrWhiteSpace(value) && Enum.IsDefined(typeof(Mode), value))
        {
            return (Mode) Enum.Parse(typeof(Mode), value);
        }

        return Mode.Maximized;
    }

    public override void Write(Utf8JsonWriter writer, Mode mode, JsonSerializerOptions options) =>
        writer.WriteStringValue(mode.ToString());
}