using System.Text.Json.Serialization;

namespace TestPriceFormation.Models;

public class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    [JsonPropertyName("net_cost")]
    public decimal NetCost { get; set; }
}
