using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestPriceFormation.ApiModels;
using TestPriceFormation.Models;

namespace TestPriceFormation.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceFormationController : ControllerBase
{
    private const string PriceInput = @"{
        ""products"": [
        {
        ""id"": 1,
        ""title"": ""Product 1"",
        ""net_cost"": 100
        },
        {
        ""id"": 2,
        ""title"": ""Product 2"",
        ""net_cost"": 200
        }
        ],
        ""tax"": 0.1,
        ""margin"": 0.2
        }";

    public PriceFormationController()
    {
    }

    [HttpGet()]
    public IActionResult Get()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<PriceResponse>(PriceInput, options);

        return Ok(CalculatePrices(result!));
    }

    private static PriceResultApi CalculatePrices(PriceResponse priceResponse)
    {
        var products = priceResponse.Products;
        var tax = priceResponse.Tax;
        var margin = priceResponse.Margin;

        var productApis =  products.Select(x => new ProductApi
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.NetCost + (x.NetCost * margin) + (x.NetCost * tax),
        });

        return new PriceResultApi
        {
            Products = productApis,
            TotalPrice = productApis.Sum(x => x.Price)
        };
    }
}
