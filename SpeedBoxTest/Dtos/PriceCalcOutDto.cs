using System.ComponentModel.DataAnnotations;

namespace SpeedBoxTest.Dtos;

public class PriceCalcOutDto
{
    [Required]
    public int Price { get; set; }
}