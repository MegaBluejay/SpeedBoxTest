using Microsoft.AspNetCore.Mvc;
using SpeedBoxTest.Dtos;

namespace SpeedBoxTest.Controllers;

[ApiController]
[Route("/")]
public class PriceCalcController : ControllerBase
{
    [HttpPost(Name = "GetPrice")]
    public PriceCalcOutDto Post(PriceCalcInDto calcIn)
    {
        return new PriceCalcOutDto { Price = 0};
    }
}