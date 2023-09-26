using System.ComponentModel.DataAnnotations;

namespace SpeedBoxTest.Dtos;

public class PriceCalcOutDto
{
    [Required]
    public double Price { get; set; }
}