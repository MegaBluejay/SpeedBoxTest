using System.Text.Json.Serialization;

namespace SpeedBoxTest.CdekApi.Dtos;

public class PriceCalcOutDto
{
    [JsonPropertyName("delivery_sum")]
    public double Price { get; set; }
}