using System.Text.Json.Serialization;

namespace DotnetApp
{
    public record Order([property: JsonPropertyName("orderId")] int OrderId,
                        [property: JsonPropertyName("quantity")] int Quantity,
                        [property: JsonPropertyName("itemName")] string ItemName);
}