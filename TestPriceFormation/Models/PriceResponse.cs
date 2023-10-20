using System.Text.Json.Serialization;

namespace TestPriceFormation.Models;

public class PriceResponse
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

    public decimal Tax { get; set; }

    public decimal Margin { get; set; }
}
