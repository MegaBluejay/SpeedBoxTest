using System.Text.Json.Serialization;
using UnitsNet;

namespace SpeedBoxTest.Dtos;

public class PriceCalcInDto
{
    [JsonIgnore]
    public Mass Weight { get; set; }
    
    [JsonPropertyName("weight")]
    public int WeightGrams
    {
        set => Weight = Mass.FromGrams(value);
    }
    
    [JsonIgnore]
    public Length Length { get; set; }

    [JsonPropertyName("length")]
    public int LengthMm
    {
        set => Length = Length.FromMillimeters(value);
    }
    
    [JsonIgnore]
    public Length Width { get; set; }

    [JsonPropertyName("width")]
    public int WidthMm
    {
        set => Width = Length.FromMillimeters(value);
    }
    
    [JsonIgnore]
    public Length Height { get; set; }

    [JsonPropertyName("height")]
    public int HeightMm
    {
        set => Height = Length.FromMillimeters(value);
    }
}