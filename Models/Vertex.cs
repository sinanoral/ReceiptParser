using System.Text.Json.Serialization;

namespace ReceiptParser.Models;

public class Vertex
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    public override string ToString()
    {
        return $"X: {X} Y: {Y}";
    }
}
