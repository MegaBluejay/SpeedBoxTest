using System.Text.Json.Serialization;
using UnitsNet;

namespace SpeedBoxTest.CdekApi.Dtos;

public class PackageInDto
{
    [JsonIgnore]
    public Mass Weight { get; set; }

    [JsonPropertyName("weight")]
    public int MassGrams => (int)Weight.Grams;
    
    [JsonIgnore]
    public Length Length { get; set; }

    [JsonPropertyName("length")]
    public int LengthCm => (int)Length.Centimeters;
    
    [JsonIgnore]
    public Length Width { get; set; }

    [JsonPropertyName("width")]
    public int WidthCm => (int)Width.Centimeters;
    
    [JsonIgnore]
    public Length Height { get; set; }

    [JsonPropertyName("height")]
    public int HeightCm => (int)Height.Centimeters;
}