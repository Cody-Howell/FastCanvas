using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastCanvas.Library;
internal class FastCanvasConverter : JsonConverter<List<CanvasTranslation>> {
    public override List<CanvasTranslation>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, List<CanvasTranslation> value, JsonSerializerOptions options) {
        writer.WriteStartArray();
        foreach (CanvasTranslation item in value) {
            writer.WriteStartObject();
            writer.WriteString("type", item.Type);

            writer.WriteStartArray("n");
            for (int i = 0; i < item.Numbers.Count(); i++) {
                writer.WriteNumberValue(item.Numbers[i]);
            }
            writer.WriteEndArray();

            writer.WriteStartArray("s");
            for (int i = 0; i < item.Strings.Count(); i++) {
                writer.WriteStringValue(item.Strings[i]);
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}
