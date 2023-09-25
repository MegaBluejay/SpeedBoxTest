using System.ComponentModel.DataAnnotations;

namespace SpeedBoxTest.Dtos;

public class PriceCalcInDto
{
    // g
    [Required]
    public int Weight { get; set; }
    
    // mm
    [Required]
    public int Length { get; set; }
    [Required]
    public int Width { get; set; }
    [Required]
    public int Height { get; set; }
    
    [Required]
    public Guid From { get; set; }
    [Required]
    public Guid To { get; set; }
}