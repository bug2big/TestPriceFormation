using System.Text.Json.Serialization;

namespace TestPriceFormation.ApiModels;

public class PriceResultApi
{
    public IEnumerable<ProductApi> Products { get; set; } = Enumerable.Empty<ProductApi>();

    [JsonPropertyName("total_price")]
    public decimal TotalPrice { get; set; }
}
