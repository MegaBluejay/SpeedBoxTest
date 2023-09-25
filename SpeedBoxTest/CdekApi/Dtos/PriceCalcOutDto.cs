using System.Text.Json.Serialization;

namespace SpeedBoxTest.CdekApi.Dtos;

public class PriceCalcOutDto
{
    [JsonPropertyName("delivery_sum")]
    public int Price { get; set; }
}