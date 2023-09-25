using System.Text.Json.Serialization;

namespace SpeedBoxTest.CdekApi.Dtos;

public class LocationInDto
{
    [JsonPropertyName("code")]
    public int Code { get; set; }
}