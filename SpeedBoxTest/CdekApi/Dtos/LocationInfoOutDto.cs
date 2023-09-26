using System.Text.Json.Serialization;

namespace SpeedBoxTest.CdekApi.Dtos;

public class LocationInfoOutDto
{
    [JsonPropertyName("code")]
    public int Code { get; set; }
}