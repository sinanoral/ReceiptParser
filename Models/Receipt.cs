using System.Text.Json.Serialization;

namespace ReceiptParser.Models;

public class Content
{
    [JsonPropertyName("locale")]
    public string Locale { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("boundingPoly")]
    public BoundingPoly BoundingPoly { get; set; }
}
