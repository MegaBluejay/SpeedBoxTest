using Microsoft.AspNetCore.Mvc;
using SpeedBoxTest.CdekApi;
using SpeedBoxTest.Dtos;

namespace SpeedBoxTest.Controllers;

[ApiController]
[Route("/")]
public class PriceCalcController : ControllerBase
{
    private readonly ICdekService _cdekService;

    public PriceCalcController(ICdekService cdekService)
    {
        _cdekService = cdekService;
    }

    [HttpPost(Name = "GetPrice")]
    public async Task<IActionResult> Post(PriceCalcInDto calcIn)
    {
        var fromTask = _cdekService.GetCodeByGuidAsync(calcIn.From);
        var toTask = _cdekService.GetCodeByGuidAsync(calcIn.To);
        var codes = await Task.WhenAll(fromTask, toTask);
        var (fromCode, toCode) = (codes[0], codes[1]);
        if (fromCode == null)
        {
            return NotFound($"City {calcIn.From} not found");
        }

        if (toCode == null)
        {
            return NotFound($"City {calcIn.To} not found");
        }
        var price = await _cdekService.GetPriceAsync(
            from: (CdekLocationCode)fromCode,
            to: (CdekLocationCode)toCode,
            weight: calcIn.Weight,
            length: calcIn.Length,
            width: calcIn.Width, 
            height: calcIn.Height);
        return Ok(new PriceCalcOutDto { Price = price });
    }
}