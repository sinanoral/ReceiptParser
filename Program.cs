using ReceiptParser.Models;
using System.Text.Json;

namespace ReceiptParser;

public class Program
{
    static void Main()
    {
        var filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)!;
        filePath = Directory.GetParent(filePath)!.FullName;
        filePath = $"{Directory.GetParent(Directory.GetParent(filePath)!.FullName)!.FullName}/input.json";

        var jsonString = File.ReadAllText(filePath);
        var receipt = JsonSerializer.Deserialize<List<Content>>(jsonString)!;

        receipt = receipt.Skip(1).OrderBy(x => x.BoundingPoly.MaxY).ToList();

        double avgDistance = GetAverageDistance(receipt);

        var d = new SortedDictionary<int, string>();
        for (int i = 0; i < receipt.Count; i++)
        {
            d.Add(receipt[i].BoundingPoly.X, receipt[i].Description);
            if (i == receipt.Count - 1 || receipt[i + 1].BoundingPoly.MaxY - receipt[i].BoundingPoly.MaxY > avgDistance)
            {
                Console.WriteLine(string.Join(" ", d.Values));
                d.Clear();
            }
        }
    }

    private static double GetAverageDistance(List<Content> receipt)
    {
        var distances = new List<int>();
        for (int i = 0; i < receipt.Count - 1; i++)
        {
            var distance = receipt[i + 1].BoundingPoly.MaxY - receipt[i].BoundingPoly.MaxY;
            distances.Add(distance);
        }

        return distances.Average();
    }
}