using System.Text.Json.Serialization;

namespace SpeedBoxTest.CdekApi.Dtos;

public class PriceCalcInDto
{
    [JsonPropertyName("type")]
    public int Type { get; set; }
    
    [JsonPropertyName("tariff_code")]
    public int TariffCode { get; set; } 
    
    [JsonPropertyName("from_location")]
    public LocationInDto From { get; set; }
    
    [JsonPropertyName("to_location")]
    public LocationInDto To { get; set; }
    
    [JsonPropertyName("packages")]
    public List<PackageInDto> Packages { get; set; }
}