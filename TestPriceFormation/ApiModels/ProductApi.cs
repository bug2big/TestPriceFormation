using System.Text.Json.Serialization;

namespace TestPriceFormation.ApiModels;

public class ProductApi
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }
}
