using ReceiptParser.Models;
using System.Text.Json.Serialization;

public class BoundingPoly
{
    [JsonPropertyName("vertices")]
    public List<Vertex> Vertices { get; set; }

    public int MaxX => Vertices.Max(x => x.X);
    public int MaxY => Vertices.Max(y => y.Y);
    public int X => Vertices.FirstOrDefault()!.X;
}
